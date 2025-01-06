using System.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Projet2Groupe1.Models;

namespace Projet2Groupe1.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public IActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]  
        public IActionResult CreateAccount (User user)
        {
            using (IUserService ius = new UserService())
            {
                if(ModelState.IsValid && ius.searchUser(user.Id) == null)
                {
                    ius.CreateUser(user.FirstName, user.LastName,  user.Phone, user.Mail,  user.Password, user.Role);
                    Console.WriteLine("Création" + user.ToString());
                }
                return View();  
            }


        }
    }
}
