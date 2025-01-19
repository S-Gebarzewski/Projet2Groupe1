using System.Net.Sockets;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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

                    if (its.BuyTicket(ticketViewModel.TicketQuantityAvailable, ticketViewModel.Event.Id))
                    {
                        its.CreateTicket
                            (ticketViewModel.Billetterie.Id, ticketViewModel.Event.Id, UserId, ticketViewModel.TicketQuantityAvailable);
                        ViewBag.Result = ticketViewModel.Billetterie.UnitPriceTicket * ticketViewModel.TicketQuantityAvailable;

                        return View("SuccessPurchaseTickets");
                    }
                    else
                    {
                        using (IEventService ies = new EventService(new DataBaseContext()))
                        {
                            Event eventItem = ies.searchEvent(ticketViewModel.Event.Id);
                            ticketViewModel.Event = eventItem;
                            ticketViewModel.Billetterie = eventItem.Billetterie;

                            ModelState.AddModelError("TicketQuantityAvailable", "Il n'y a pas suffisamment de billets disponibles.");
                            return View(ticketViewModel);
                        }
                    }
                }
            }
            
        }
        

        [HttpPost]
        public IActionResult SuccessPurchaseTickets(PaymentViewModel PaymentViewModel) 
        {
            Console.WriteLine("Je suis dans SuccessPurchaseTickets");
            if (!ModelState.IsValid)
            {
                foreach (var key in ModelState.Keys)
                {
                    var state = ModelState[key];
                    foreach (var error in state.Errors)
                    {
                        Console.WriteLine($"Clé : {key}, Erreur : {error.ErrorMessage}");
                    }
                }
                return RedirectToAction("Error", "Error", new { errorCode = 6, Message = "Le paiement n'a pas ete valide. Veuillez recommencer le paiement." });
            }
            else
            {
                ViewData["IsAuthenticated"] = HttpContext.User.Identity.IsAuthenticated;
                ViewData["Role"] = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                string actionPath = "Dashboard" + ViewData["Role"];
                return RedirectToAction(actionPath, "Login");
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
                    return RedirectToAction("Error", "Error", new { errorCode = 7, Message = "L'evenement que vous avez choisi n'est plus disponible." });
                }
            }
        }
    }
}
