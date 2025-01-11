using System.Data;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
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
                    ius.CreateUser(user.FirstName, user.LastName, user.Phone, user.Mail, user.Password, user.Newsletter, user.Role);
                    Console.WriteLine("Création" + user.ToString());
                }
                return View();
            }




        }
      
        public IActionResult Connection()

        {
            using (IUserService ius = new UserService(new DataBaseContext()))
            {
                Console.WriteLine("IsAuthenticated est a " + HttpContext.User.Identity.IsAuthenticated);
                UserViewModel uvm = new UserViewModel
                {
                    Authenticate = HttpContext.User.Identity.IsAuthenticated
                };
                              
            if (uvm.Authenticate)
                {
                    Console.WriteLine("je suis deja authentifie");
                    uvm.User = ius.ObtainUser(HttpContext.User.Identity.Name);
                }
                
                return View(uvm);
            }

        }
        [HttpPost]
        public IActionResult Connection(UserViewModel userViewModel, string returnUrl)
        {

            using (IUserService ius = new UserService(new DataBaseContext()))
            {
                User user = ius.Authentication(userViewModel.User.Mail, userViewModel.User.Password);
                if (user != null) // bon mot de passe
                {
                    Console.WriteLine("connexion reussie");
                    List<Claim> userClaims = new List<Claim>()
                    {
                         new Claim(ClaimTypes.Name, user.Id.ToString()),
                         new Claim(ClaimTypes.Role, user.Role.ToString()),
                         
                    };
                    
                    Console.WriteLine(userClaims);

                    var ClaimIdentity = new ClaimsIdentity(userClaims, "User Identity");

                    var userPrincipal = new ClaimsPrincipal(new[] { ClaimIdentity });

                    HttpContext.SignInAsync(userPrincipal);

                    if (!string.IsNullOrWhiteSpace(returnUrl) && Url.IsLocalUrl(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    //return Redirect("/Login/DashBoardAdmin");
                    return Redirect(user.Role);
                }
                ModelState.AddModelError("Utilisateur.Nom", "Nom et/ou mot de passe incorrect(s)");
                Console.WriteLine("Mail ou mot de passe de " + user.Mail + " " + user.Password + "incorrects");
                return View(userViewModel);
            }
           

        }

        [Authorize]
        public IActionResult Redirect(UserRole dashboardType)
        {
            Console.WriteLine("voici le dashboardtype : "+dashboardType.ToString());
            switch (dashboardType.ToString())
            {
                case "ADMIN":
                    return View("DashBoardAdmin");

                case "MEMBER":
                    return View("DashBoardMember");

                case "PREMIUM":
                    return View("DashBoardPremium");
                case "ORGANIZER":
                    return View("DashBoardOrganizer");
                case "PROVIDER":
                    return View("DashBoardProvider");
                default:
                    Console.WriteLine("je suis la");


                    return null;
            }
        }
       
        public IActionResult Disconnection()
        {
            HttpContext.SignOutAsync();
          
            return RedirectToAction("Connection", "Login");
        }


    }
}
