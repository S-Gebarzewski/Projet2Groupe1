using Microsoft.AspNetCore.Mvc;

namespace Projet2Groupe1.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult MemberRegistration()
        {
            return View();
        }
    }
}
