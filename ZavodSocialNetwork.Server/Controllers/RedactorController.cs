using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop.Implementation;
using System.Diagnostics.Contracts;
using System.Numerics;
using ZavodSocialNetwork.Server.Models;
using ZavodSocialNetwork.Server.ViewModels;
using Contract = ZavodSocialNetwork.Server.Models.Contract;

namespace ZavodSocialNetwork.Server.Controllers
{
    [Route("api/main")]
    [ApiController]
    public class RedactorController : Controller
    {
        public ApplicationContext context;
        public List<ContractViewModel> CL;

        public RedactorController(ApplicationContext db)
        {
            context = db;
            GetData();
        }

        //Здесь идут все Read-методы
        //Отдельно, потому что это удобней

        //Этот метод на поиск оферов по определённому контракту
        [HttpGet]
        public IEnumerable<ContractViewModel>? GetOffers(ContractViewModel contr, UserViewModel user)
        {
            List<Contract> temp = [.. context.Contracts.AsNoTracking()];
            List<ContractViewModel> data = [];
            int id = (int)SearchOrgId(user.organisation);
            foreach (var contract in temp)
            {
                if (contract.status == "Offer" && (contract.receiptid == id || contract.executorId == id) && contract.byId == contr.id)
                {
                    data.Add(new ContractViewModel
                    {
                        id = contract.Id,
                        executor = SearchOrg(contract.executorId),
                        receiver = SearchOrg(contract.receiverId),
                        product = SearchProd(contract.productId),
                        status = contract.status,
                        exconditions = contract.exconditions,
                        receipt = SearchRecipt(contract.receiptid),
                        regularity = contract.regularity
                    });
                }
            }
            if (data.Count == 0)
            {
                return null;
            }    
            return data;
        }

        //все контракты, что не являются оферами
        [HttpGet]
        public IEnumerable<ContractViewModel> Table()
        {
            List<ContractViewModel> temp = [];
            foreach (var item in CL)
            {
                if (item.status != "NoN")
                {
                    temp.Add(item);
                }
            }
            return temp;
        }

        //те контракты, у которых нет получателя
        [HttpGet]
        public IEnumerable<ContractViewModel> TableProducts() 
        {
            List<ContractViewModel> temp = [];
            foreach (var item in CL) 
            {
                if (item.receiver == null && item.status != "NoN")
                {
                    temp.Add(item);
                }
            }
            return temp;
        }

        //те контракты, у которых нет исполнителя
        [HttpGet]
        public IEnumerable<ContractViewModel> TableNeeds() 
        {
            List<ContractViewModel> temp = [];
            foreach (var item in CL)
            {
                if (item.executor == null && item.status != "NoN")
                {
                    temp.Add(item);
                }
            }
            return temp;
        }

        //контракты клиента
        [HttpGet]
        public IEnumerable<ContractViewModel> TableMe(User user)
        {
            List<ContractViewModel> temp = [];
            foreach (var item in CL)
            {
                if (item.byId == SearchOrgId(user.Organisation))
                {
                    temp.Add(item);
                }
            }
            return temp;
        }

        //контракты для подписи
        [HttpGet]
        public IEnumerable<ContractViewModel> TableForUs()
        {
            List<ContractViewModel> temp = [];
            foreach (var item in CL)
            {
                if (item.status == "ApprovedByBothSides")
                {
                    temp.Add(item);
                }
            }
            return temp;
        }

        //контракты-оферы
        [HttpGet]
        public IEnumerable<ContractViewModel> TableForMe(User user)
        {
            List<ContractViewModel> temp = [];
            foreach (var item in CL)
            {
                if (item.status == "ApprovedLikeOffer" && item.byId != SearchOrgId(user.Organisation))
                {
                    temp.Add(item);
                }
            }
            return temp;
        }

        //CRUD-методы - первая половина муторной и неинтересной части

        //В Edit'ах можно было бы воспользоваться переопределением индексации
        //...но у бэка температура тела выше рабочей температуры процессора

        //Контракт
        [HttpPost]
        public bool CreateContract(ContractViewModel contract)
        {
            try
            {
                if (contract != null)
                {
                    Contract nContact = new()
                    {
                        executorId = SearchOrgId(contract.executor),
                        receiverId = SearchOrgId(contract.receiver),
                        productId = contract.product.Id,
                        quntity = contract.quntity,
                        exconditions = contract.exconditions,
                        receiptid = contract.receipt.Id,
                        regularity = contract.regularity
                    };
                    context.Contracts.Add(nContact);
                }
            }
            catch
            {
                return false;
            }
            context.SaveChanges();
            return true;
        }
        [HttpGet]
        public ContractViewModel EditContract(int id)
        {
            foreach (var contract in CL)
            {
                if (contract.id == id)
                {
                    return contract;
                }
            }
            return null;
        }
        [HttpPost]
        public bool EditContract(ContractViewModel contract) 
        {
            foreach (var cont in CL)
            {
                if (cont.id == contract.id)
                {
                    CL.Remove(cont);
                    CL.Add(contract);
                    foreach (var item in context.Contracts)
                    {
                        if (item.Id == contract.id)
                        {
                            context.Contracts.Remove(item);
                        }
                    }
                    Contract nContact = new()
                    {
                        executorId = SearchOrgId(contract.executor),
                        receiverId = SearchOrgId(contract.receiver),
                        productId = contract.product.Id,
                        quntity = contract.quntity,
                        exconditions = contract.exconditions,
                        receiptid = contract.receipt.Id,
                        regularity = contract.regularity
                    };
                    context.Contracts.Add(nContact);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }
        [NonAction]
        public bool DeleteContract(ContractViewModel contract)
        {
            //Нужно получить всё взаимосвязанные данные (кроме продукта) и удалить всё скопом
            foreach (var item in context.Contracts)
            {
                if (item.Id == contract.id && item.executorId == SearchOrgId(contract.executor) && item.receiverId == SearchOrgId(contract.receiver))
                {
                    context.Contracts.Remove(item);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        //Далее идут 3 метода: Одобрить/Отменить/Закрыть(завершить)

        //Чекаем текущий статус, а затем ставим соответствующий
        [HttpPost]
        public void Aprove(ContractViewModel contract, UserViewModel user)
        {
            if (contract.status == "Offer" && contract.byId == SearchOrgId(user.organisation))
            {
                contract.status = "ApprovedLikeOffer";
            }
            else
            {
                if (contract.status == "ApprovedLikeOffer" && user.organisation != null)
                {
                    contract.status = "ApprovedByBothSides";
                }
                else
                {
                    contract.status = "Completed";
                }
            }
            EditContract(contract);
        }
        [HttpPost]
        public void Cancel(ContractViewModel contract)
        {
            if (contract.status == "Offer")
            {
                DeleteContract(contract);
                return;
            }
            if (contract.status != "NoN")
            {
                Reject(contract); 
                return;
            }
            contract.status = "Canceled";
            EditContract(contract);
        }
        [NonAction] //отменяем принятый офер
        public void Reject(ContractViewModel contract)
        {
            if (contract.byId == SearchOrgId(contract.receiver))
            {
                contract.executor = null;
            }
            else
            {
                contract.receiver = null;
            }
            contract.status = "NoN";
            EditContract(contract);
        }

        //Товар/продукт
        [HttpPost]
        public bool CreateProduct(Product product)
        {
            try
            {
                Product nprod = new()
                {
                    naming = product.naming,
                    description = product.description
                };
                context.Product.Add(nprod);
            }
            catch
            {
                return false;
            }
            context.SaveChanges();
            return true;
        }
        [HttpPost]
        public bool DeleteProduct(int id)
        {
            //Тут сложнее, тут либо удалять все взаимосвязанные вещи, либо запрет
            //По факту здесь нужно только удаление, если нет связей
            foreach (var contract in context.Contracts)
            {
                if (contract.productId == id)
                {
                    return false;
                }
            }
            context.Product.Remove(SearchProd(id));
            return true;
        }

        //Метод составления предложений
        //Вопросы к Р.А.Н.
        [HttpPost]
        public IEnumerable<ContractViewModel> SelectOffer(ContractViewModel contract)
        {
            try
            {
                Contract nContact = new()
                {
                    executorId = SearchOrgId(contract.executor),
                    receiverId = SearchOrgId(contract.receiver),
                    productId = contract.product.Id,
                    status = contract.status,
                    exconditions = contract.exconditions,
                    quntity = contract.quntity,
                    receiptid = contract.receipt.Id,
                    regularity = contract.regularity
                };
                context.Contracts.Add(nContact);
                List<ContractViewModel> alloffer = [];
                foreach (var item in CL)
                {
                    if (item.executor == null && item.product.naming == contract.product.naming)
                    {
                        alloffer.Add(item);
                    }
                    else if (item.receiver == null && item.product.naming == contract.product.naming)
                    {
                        alloffer.Add(item);
                    }
                }
                return alloffer;
            }
            catch
            {
                return null;
            }
        }


        //Далее идут служебные методы для работы с инфой. Вторая половина муторной и неинтересной части

        [NonAction]
        public void GetData()
        {
            List<Contract> temp = [.. context.Contracts.AsNoTracking()];
            List<ContractViewModel> data = [];
            foreach(var contract in temp) 
            {
                if (contract.status != "Offer")
                {
                    data.Add(new ContractViewModel
                    {
                        id = contract.Id,
                        executor = SearchOrg(contract.executorId),
                        receiver = SearchOrg(contract.receiverId),
                        product = SearchProd(contract.productId),
                        quntity = contract.quntity,
                        status = contract.status,
                        exconditions = contract.exconditions,
                        receipt = SearchRecipt(contract.receiptid),
                        regularity = contract.regularity
                    });
                }
            }
            CL = data;
        }

        [NonAction]
        public string SearchOrg(int? id) 
        {
            if (id != null)
            {
                List<User> users = [.. context.Users.AsNoTracking()];
                foreach (var user in users)
                {
                    if (user.Id == id)
                    {
                        return user.Organisation;
                    }
                }
            }
            return null;
        }

        [NonAction]
        public int? SearchOrgId(string? org)
        {
            if (org != null)
            {
                List<User> users = [.. context.Users.AsNoTracking()];
                foreach (var user in users)
                {
                    if (user.Organisation == org)
                    {
                        return user.Id;
                    }
                }
            }
            return null;
        }

        [NonAction]
        public Receipt SearchRecipt(int id)
        {
            List<Receipt> p = [.. context.Receipts.AsNoTracking()];
            foreach (Receipt receipt in p)
            {
                if (receipt.Id == id)
                {
                    Receipt rec = new();
                    rec.Id = id;
                    rec.total_payment = receipt.total_payment;
                    rec.expenses = receipt.expenses;
                    rec.our_share = receipt.our_share;
                    return rec;
                }
            }
            return null;
        }

        [NonAction]
        public Product SearchProd(int id)
        {
            foreach (var item in context.Product) 
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
        
        [NonAction]
        public string GetStatus(ContractViewModel contract)
        {
            return "NoN";
        }
    }
}
