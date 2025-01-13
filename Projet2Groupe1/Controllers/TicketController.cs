using Microsoft.AspNetCore.Mvc;
using Projet2Groupe1.Models;
using Projet2Groupe1.ViewModels;

namespace Projet2Groupe1.Controllers
{
    public class TicketController : Controller
    {
        [HttpGet]

        public IActionResult PurchaseTicket(int Id)
        {
            using(IEventService ies = new EventService(new DataBaseContext()))
           {
                Event eventItem = ies.searchEvent(Id);

                if (eventItem != null)
                {

                    return View(eventItem);

                }
                else {
                    return View("Error"); }

            }

            //TicketViewModel ticketViewModel = new TicketViewModel();

            //return View(ticketViewModel);

          
        }


        //[HttpPost]

        //public IActionResult PurchaseTicket(TicketViewModel ticketViewModel)
        //{
        //    TicketViewModel ticketViewModel = new TicketViewModel();



        //    return View(ticketViewModel);
        //}

    }

}
