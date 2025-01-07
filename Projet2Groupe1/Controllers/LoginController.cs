using System.Data;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using Projet2Groupe1.Models;
using Projet2Groupe1.ViewModels;

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
        public IActionResult CreateAccount(User user)
        {
            using (IUserService ius = new UserService(new DataBaseContext()))
            {
                Console.WriteLine("vérification du model state " + ModelState.IsValid);
                if (ModelState.IsValid && ius.searchUser(user.Id) == null)
                {
                    ius.CreateUser(user.FirstName, user.LastName, user.Phone, user.Mail, user.Password, user.Role);
                    Console.WriteLine("Création" + user.ToString());
                }
                return View();
            }




        }
      
        public IActionResult Connection()

        {
            using (IUserService ius = new UserService(new DataBaseContext()))
            {
                UserViewModel uvm = new UserViewModel
                {
                    Authenticate = HttpContext.User.Identity.IsAuthenticated
                };
                Console.WriteLine("on est dans la merde" + uvm.Authenticate);
               



            if (uvm.Authenticate)
                {
                    Console.WriteLine("je suis deja authentifier");
                    uvm.User = ius.ObtainUser(HttpContext.User.Identity.Name);
                }Console.WriteLine("on est dans la uvm");
                return View(uvm);
            }

        }
        [HttpPost]
        public IActionResult Connection(UserViewModel userViewModel, string returnUrl)
        {
            Console.WriteLine("on est juste dans le néant");
            using (IUserService ius = new UserService(new DataBaseContext()))
            {
                Console.WriteLine("on est vraiment dans la hess");

                User user = ius.Authentication(userViewModel.User.Mail, userViewModel.User.Password);
                if (user != null) // bon mot de passe
                {
                    Console.WriteLine("connexion reussie");
                    List<Claim> userClaims = new List<Claim>()
         {
             new Claim(ClaimTypes.Name, user.Id.ToString()),
             new Claim(ClaimTypes.Role, user.Role.ToString()),
             

         };

                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });

                    HttpContext.SignInAsync(userPrincipal);

                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {

                        Console.WriteLine("on est dans le if");
                        return Redirect(returnUrl);
                    }
                    Console.WriteLine("on est dans le else ");
                    return Redirect("/Home/Index/1");
                    
                }
                ModelState.AddModelError("Utilisateur.Nom", "Nom et/ou mot de passe incorrect(s)");
                Console.WriteLine("on est dans la UserViewModel");
                return View(userViewModel);
            }
           

        }
    }
}
