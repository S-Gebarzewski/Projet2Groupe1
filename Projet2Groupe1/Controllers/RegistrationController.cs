using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Mvc;
using Projet2Groupe1.Models;
using Projet2Groupe1.ViewModels;

namespace Projet2Groupe1.Controllers
{
    public class RegistrationController : Controller
    {
        [HttpGet]
        public IActionResult MemberRegistration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult MemberRegistration(User user, Member member)
        {
            using (IUserService ius = new UserService(new DataBaseContext()))
            {
                Console.WriteLine("ModelState de User " + ModelState.IsValid);
                if (ModelState.IsValid && ius.searchUser(user.Id) == null)
                {
                    user.Id = ius.CreateUser(user.FirstName, user.LastName, user.Phone, user.Mail, user.Password, user.Newsletter, user.Role = UserRole.MEMBER);
                    Console.WriteLine(user.ToString());
                }

                using (IMemberService ims = new MemberService(new DataBaseContext()))
                {
                    Console.WriteLine("ModelState de member " + ModelState.IsValid);
                    if (ModelState.IsValid)
                    {
                        ims.CreateMember(member.Age, member.City, member.ZipCode, member.IsPremium, user.Id);
                    }

                }
                return View();
            }


        }

        [HttpGet]
        public IActionResult ProviderRegistration()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProviderRegistration(User user, Provider provider)
        {
            using (IUserService ius = new UserService(new DataBaseContext()))
            {
                if(ModelState.IsValid && ius.searchUser(user.Id) == null)
                     user.Id = ius.CreateUser(
                     user.FirstName,
                     user.LastName,
                     user.Phone,
                     user.Mail,
                     user.Password,
                     user.Newsletter,
                     user.Role = UserRole.PROVIDER);
            }

            using (IProviderService ips = new ProviderService(new DataBaseContext()))
            {
                provider.UserId = user.Id;
                if (ModelState.IsValid)
                {
                    ips.CreateProvider(provider.Position,
                                       provider.ServiceType,
                                       provider.Adress,
                                       provider.UserId);

                }
                return View();
            }

        }
    }
}
