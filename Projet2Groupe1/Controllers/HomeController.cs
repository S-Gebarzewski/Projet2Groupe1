using Microsoft.AspNetCore.Mvc;

namespace Projet2Groupe1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index(string id)
       
        {
            if (string.IsNullOrEmpty(id))
            {
                return View("Error");
            }
            else
            {
                return View();
            }
        }
    }
}
