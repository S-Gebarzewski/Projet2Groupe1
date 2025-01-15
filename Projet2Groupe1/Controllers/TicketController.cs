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
                    TicketViewModel ticketViewModel = new TicketViewModel
                    {
                        Event = eventItem,
                        Billetterie = eventItem.Billetterie,
                    };

                    return View(ticketViewModel);

                }
                else {
                    return View("Error"); }

            }

            //TicketViewModel ticketViewModel = new TicketViewModel();

            //return View(ticketViewModel);

          
        }


        [HttpPost]
        public IActionResult PurchaseTicket(TicketViewModel ticketViewModel)
        {
            using (ITicketService its = new TicketService(new DataBaseContext()))
            {
                using (IUserService ius = new UserService(new DataBaseContext()))
                {
                    UserViewModel uvm = new UserViewModel
                    {
                        Authenticate = HttpContext.User.Identity.IsAuthenticated
                    };
                    Console.WriteLine("IsAuthenticated est a " + uvm.Authenticate);
                    if (!uvm.Authenticate)
                    {
                        return RedirectToAction("Error", "Error", new { errorCode = 1,
                            Message = "Veuillez vous connecter" });
                    }

                    if (its.BuyTicket(ticketViewModel.TicketQuantityAvailable, ticketViewModel.Event.Id ))
                    {
                        its.CreateTicket
                            (ticketViewModel.Billetterie.Id, ticketViewModel.Event.Id, ticketViewModel.User.Id, ticketViewModel.TicketQuantityAvailable);
                        ViewBag.Result = ticketViewModel.Billetterie.UnitPriceTicket * ticketViewModel.TicketQuantityAvailable;
                        return View("SuccessTicket");
                    }

                    else
                    {
                        using (IEventService ies = new EventService(new DataBaseContext()))
                        {
                            Event eventItem = ies.searchEvent(ticketViewModel.Event.Id);
                            ticketViewModel.Event = eventItem;
                            ticketViewModel.Billetterie = eventItem.Billetterie;
                            ModelState.AddModelError("TicketQuantityAvailable", "Il n'y a pas suffisamment de billets disponibles.");
                            /*  return View(ticketViewModel);*/
                            return View(ticketViewModel);
                        }


                    }
                }
            }
            
        }

    }

}
