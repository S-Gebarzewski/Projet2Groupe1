using Microsoft.AspNetCore.Mvc;
using Projet2Groupe1.Models;

namespace Projet2Groupe1.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult RegisterOrganizer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RegisterOrganizer(User user,Organizer organizer)
        {
            using (IUserService ius = new UserService(new DataBaseContext()))
            {
                Console.WriteLine("vérification du model state " + ModelState.IsValid);
                if (ModelState.IsValid && ius.searchUser(user.Id) == null)
                {
                    user.Id = ius.CreateUser(user.FirstName, user.LastName, user.Phone, user.Mail, user.Password,user.Newsletter, user.Role);
                    Console.WriteLine("Création" + user.Id);
                }
                Console.WriteLine("Apres le if de createuser");


                using (IOrganizerService ios = new OrganizerService(new DataBaseContext()))
                {
                    if (ModelState.IsValid)
                    {
                        Console.WriteLine("dans le if ");
                        ios.CreateOrganizer(organizer.Function, organizer.Denomination, organizer.RIB, organizer.Adress,user.Id);
                    }
                    Console.WriteLine("Apresle if de createOrganizer");

                }
                return View();
            }


        }
    }
}
