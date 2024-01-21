using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZavodSocialNetwork.Server.Models;
using ZavodSocialNetwork.Server.ViewModels;

namespace ZavodSocialNetwork.Server.Controllers
{
    [Route("enter")]
    [ApiController]
    public class EnterController : ControllerBase
    {
        public ApplicationContext context;
        public List<User> data;

        public EnterController(ApplicationContext db)
        {
            data = [..context.Users.AsNoTracking()];
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> Get()
        {
            return data;
        }

        [HttpPost]
        public bool Login([FromBody]UserViewModel loger)
        {
            foreach (var user in data) 
            {
                if (user.Phone == loger.phone && user.Password == loger.password)
                {
                    return true;
                }
            }
            return false;
        }

        [HttpPost]
        public bool Registration([FromBody]UserViewModel newUser)
        {
            foreach(var user in data) 
            {
                if (newUser.phone == user.Phone) 
                {
                    return false;
                }
            }
            context.Users.Add(new User 
            { 
                Organisation = newUser.organisation, 
                Phone = newUser.phone, 
                Password = newUser.password, 
                Role = "User" //Администрации не нужно создавать через регистрацию аккаунты
            });
            context.SaveChanges();
            return true;
        }

        //скорее всего, будет нужен в другом контроллере
        [HttpGet]
        public string CheckRole(int id)
        {
            object us = from u in data where u.Id == id select u;
            User user = (User)us;
            return user.Role;
        }
    }
}
