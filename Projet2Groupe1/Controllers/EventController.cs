using Microsoft.AspNetCore.Mvc;

namespace Projet2Groupe1.Controllers
{
    public class EventController : Controller
    {
        public IActionResult Catalog()
        {
            return View();
        }

        public IActionResult TicketDetail()
        {
            return View();
        }

        public IActionResult PurchaseTicket()
        {
            return View();
        }
    }
}
