using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ZavodSocialNetwork.Server.Models;
using ZavodSocialNetwork.Server.ViewModels;

namespace ZavodSocialNetwork.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnterController : Controller
    {
        /*public ApplicationContext context;*/
        public List<User> data = new();

        public EnterController(/*ApplicationContext db*/)
        {
            //data = [.. db.Users.AsNoTracking()];
            data.Add(new User
            {
                Id = 1,
                Phone = "88005553535",
                Organization = "САМАЯ ЛУЧШАЯ",
                Password = "МЕНЯ БИЛИ В ДЕТСТВЕ",
            });
        }

        
        public bool Login(UserViewModel loger)
        {
            foreach (var user in data) 
            {
                if (user.Organization == loger.Organization && user.Phone == loger.Phone && user.Password == loger.Password)
                {
                    return true;
                }
            }
            return false;
        }
        [HttpGet]
        public User Get()
        {
            /*data.Add(new User
            {
                Id = 1,
                Phone = "88005553535",
                Organization = "ООО-МАТЬ",
                Password = "ООО-ПАПА",
            });*/
            return data[0];
        }

        public bool RegistrationAsync(UserViewModel newUser)
        {
            foreach(var user in data) 
            {
                if (newUser.Phone == user.Phone) 
                {
                    return false;
                }
            }
            /*context.Users.Add(new User 
            { 
                Organization = newUser.Organization, 
                Phone = newUser.Phone, 
                Password = newUser.Password, 
                Role = "User"
            });
            context.SaveChanges();*/
            return true;
        }

        //скорее всего, будет нужен в другом контроллере
        public string CheckRole(int id)
        {
            object us = from u in data where u.Id == id select u;
            User user = (User)us;
            return user.Role;
        }
    }
}
