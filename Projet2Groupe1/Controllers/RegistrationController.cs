using Microsoft.AspNetCore.Mvc;
using Projet2Groupe1.Models;

namespace Projet2Groupe1.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateAccount(User user,Organizer organizer)
        {
            using (IUserService ius = new UserService(new DataBaseContext()))
            {
                Console.WriteLine("vérification du model state " + ModelState.IsValid);
                if (ModelState.IsValid && ius.searchUser(user.Id) == null)
                {
                    ius.CreateUser(user.FirstName, user.LastName, user.Phone, user.Mail, user.Password, user.Role);
                    Console.WriteLine("Création" + user.ToString());
                }
               

            }
            using (IOrganizerService ios = new OrganizerService(new DataBaseContext()))
            {
                if (ModelState.IsValid)
                {
                    ios.CreateOrganizer(organizer.Function, organizer.Denomination, organizer.RIB, organizer.Adress, organizer.UserId);
                }
                return View();

            }



        }
    }
}
