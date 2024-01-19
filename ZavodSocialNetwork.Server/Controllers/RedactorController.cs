using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Numerics;
using ZavodSocialNetwork.Server.Models;
using ZavodSocialNetwork.Server.ViewModels;

namespace ZavodSocialNetwork.Server.Controllers
{
    [Route("Main")]
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

        //те контракты, у которых нет получателя
        [HttpGet]
        public IEnumerable<ContractViewModel> TableProducts() 
        {
            List<ContractViewModel> temp = [];
            foreach (var item in CL) 
            {
                if (item.receiver == null && item.status != "NotReady")
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
                if (item.executor == null && item.status != "NotReady")
                {
                    temp.Add(item);
                }
            }
            return temp;
        }

        /*[HttpPost]
        public bool Create(ContractViewModel contract, List<ProductPackageViewModel> packages, List<ProductPositionViewModel> positions, List<ProductViewModel> products) 
        {
            try
            {
                Contract nContact = new()
                {
                    executorId = SearchOrgId(contract.executor),
                    receiverId = SearchOrgId(contract.receiver),
                    product_package = contract.id, //id у пакетов и позиций всегда такой же, как и у контракта
                    //но как собирать инфу по пакетам и позициям?
                    status = contract.status,
                    exconditions = contract.exconditions,
                    receiptid = contract.receipt.Id,
                    regularity = contract.regularity
                };
                context.Contracts.Add(nContact);
                for (int i = 0; i < packages.Count(); i++) 
                {
                    Product_package product = new()
                    {
                        Id = contract.id,
                        executorid = SearchOrgId(packages[i].executor),
                        
                    };
                }
            }
            catch
            {
                return false;
            }
            context.SaveChanges();
            return true;
        }*/
        
        [NonAction]
        public void GetData()
        {
            List<Contract> temp = [.. context.Contracts.AsNoTracking()];
            List<ContractViewModel> data = [];
            foreach(var contract in temp) 
            {
                data.Add(new ContractViewModel
                {
                    id = contract.Id,
                    executor = SearchOrg(contract.executorId),
                    receiver = SearchOrg(contract.receiverId),
                    packages = SearchPPackages(contract.product_package),
                    status = contract.status,
                    exconditions = contract.exconditions,
                    receipt = SearchRecipt(contract.receiptid),
                    regularity = contract.regularity
                });
            }
            CL = data;
        }

        [NonAction]
        public List<ProductPackageViewModel> SearchPPackages(int id) 
        {
            List<ProductPackageViewModel> ppvm = [];
            List<Product_package> pp = [.. context.ProductPackages.AsNoTracking()];
            List<User> users = [.. context.Users.AsNoTracking()];
            foreach (var productpackage in pp) 
            {
                if (productpackage.Id == id) 
                {
                    ppvm.Add(new ProductPackageViewModel
                    {
                        id = productpackage.Id,
                        executor = SearchOrg(productpackage.executorid),
                        positions = SearchPPositions(productpackage.Id)
                    });
                }
            }
            return ppvm;
        }

        [NonAction]
        public string SearchOrg(int id) 
        {
            List<User> users = [.. context.Users.AsNoTracking()];
            foreach (var user in users) 
            {
                if (user.Id == id) 
                {
                    return user.Organisation;
                }
            }
            return null;
        }

        [NonAction]
        public int SearchOrgId(string org)
        {
            List<User> users = [.. context.Users.AsNoTracking()];
            foreach (var user in users)
            {
                if (user.Organisation == org)
                {
                    return user.Id;
                }
            }
            return -1; //этого по-идее случиться не должно
        }

        [NonAction]
        public List<ProductPositionViewModel> SearchPPositions(int id) 
        {
            List<ProductPositionViewModel> ppvm = [];
            List<Product_position> pp = [.. context.ProductPositions.AsNoTracking()];
            foreach (var position in pp)
            {
                if (position.Id == id)
                {
                    ppvm.Add(new ProductPositionViewModel
                    {
                        id = position.Id,
                        product = SearchProduct(position.idproduct),
                        naming = position.naming,
                        quantity = position.quantity,
                        status = position.status
                    });
                }
            }
            return ppvm;
        }

        [NonAction]
        public ProductViewModel SearchProduct(int id)
        {
            List<Product> p = [.. context.Product.AsNoTracking()];
            foreach(var product in p)
            {
                if (product.Id == id) 
                {
                    ProductViewModel per = new();
                    per.id = product.Id;
                    per.description = product.description;
                    return per;
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
    }
}
