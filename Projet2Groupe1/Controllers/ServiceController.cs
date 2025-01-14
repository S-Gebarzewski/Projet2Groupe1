using Microsoft.AspNetCore.Mvc;

namespace Projet2Groupe1.Controllers
{
    public class ServiceController : Controller
    {
        public IActionResult CreateService()
        {
            return View();
        }

        public IActionResult MyServices()
        {
            return View();
        }
    }
}
