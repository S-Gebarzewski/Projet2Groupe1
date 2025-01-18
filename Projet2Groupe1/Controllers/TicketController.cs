using System.Security.Claims;
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
                    ViewData["IsAuthenticated"] = HttpContext.User.Identity.IsAuthenticated;
                    ViewData["Role"] = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                    return View(ticketViewModel);
                }
                else 
                {
                    return RedirectToAction("Error", "Error", new { errorCode = 5, Message = "Veuillez vous connecter ou vous inscrire pour acheter votre billet." });
                }

            }          
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
                            Message = "Veuillez vous connecter ou vous inscrire pour acheter votre billet." });
                    }

                    int UserId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.Name).Value);

                    ViewData["IsAuthenticated"] = HttpContext.User.Identity.IsAuthenticated;
                    ViewData["Role"] = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                    if (its.BuyTicket(ticketViewModel.TicketQuantityAvailable, ticketViewModel.Event.Id ))
                    {
                        its.CreateTicket
                            (ticketViewModel.Billetterie.Id, ticketViewModel.Event.Id, UserId, ticketViewModel.TicketQuantityAvailable);
                        ViewBag.Result = ticketViewModel.Billetterie.UnitPriceTicket * ticketViewModel.TicketQuantityAvailable;
                        //ViewData["IsAuthenticated"] = HttpContext.User.Identity.IsAuthenticated;
                        //ViewData["Role"] = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                        return View("SuccessTicket");
                    }
                    else
                    {
                        using (IEventService ies = new EventService(new DataBaseContext()))
                        {
                            Event eventItem = ies.searchEvent(ticketViewModel.Event.Id);
                            ticketViewModel.Event = eventItem;
                            ticketViewModel.Billetterie = eventItem.Billetterie;
                            //// manque les view data role et isauthenticated
                            //ViewData["IsAuthenticated"] = HttpContext.User.Identity.IsAuthenticated;
                            //ViewData["Role"] = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                            ModelState.AddModelError("TicketQuantityAvailable", "Il n'y a pas suffisamment de billets disponibles.");
                            return View(ticketViewModel);
                        }
                    }
                }
            }
            
        }
        public IActionResult PurchaseHistory()
        {
            using (ITicketService its = new TicketService(new DataBaseContext()))
            {
                int UserId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.Name).Value);
                List<UserTicket> tickets = its.GetTicketsByUserId(UserId);

                if (tickets != null)
                {
                    List<TicketViewModel> tvm = tickets.Select(t => new TicketViewModel
                    {
                        Event = t.Event,
                        TicketQuantityAvailable = t.Quantity,
                        QuantityPurchased = t.Quantity,

                    }).ToList();
                    ViewData["IsAuthenticated"] = HttpContext.User.Identity.IsAuthenticated;
                    ViewData["Role"] = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                    return (View(tvm));
                }
                else
                {
                    return View("Error"); // return view error
                }
            }
        }
        
        public IActionResult SuccessPurchaseTickets(PaymentViewModel PaymentViewModel) 
        {
            Console.WriteLine("Je suis dans SuccessPurchaseTickets");
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Error", "Error", new { errorCode = 1, Message = "Veuillez vous connecter ou vous inscrire pour acheter votre billet." });
            }
            else
            {

                return View();
            }
        }
    }
}
