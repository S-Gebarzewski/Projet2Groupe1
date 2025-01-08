using Microsoft.AspNetCore.Mvc;
using Projet2Groupe1.Models;

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
                Console.WriteLine("vérification du model state " + ModelState.IsValid);
                if (ModelState.IsValid && ius.searchUser(user.Id) == null)
                {
                    ius.CreateUser(user.FirstName, user.LastName, user.Phone, user.Mail, user.Password, user.Newsletter, user.Role);
                    Console.WriteLine(user.ToString());
                }

                using (IMemberService ims = new MemberService(new DataBaseContext())) 
                {
                    if (ModelState.IsValid) 
                    {
                        Console.WriteLine("Avant inscirption de member, la cle etrangere UserId vaut " + user.Id);
                        ims.CreateMember(member.Age, member.City, member.ZipCode, member.IsPremium, user.Id);
                        Console.WriteLine(member.ToString());
                    }

                }
                return View();
            }




        }
    }
}
