using Microsoft.AspNetCore.Mvc;
using Projet2Groupe1.Models;
using Projet2Groupe1.ViewModels;

namespace Projet2Groupe1.Controllers
{
    public class EventController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

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

        [HttpGet]
        public IActionResult CreateEvent()
        {
            return View();
        }
        [HttpPost]

        //public int CreateEvent(TypeEvent TypeEvent, string NameEvent, DateTime StartEvent, DateTime EndEvent, Adress Adress, Artist Artist, Ticket Ticket, Service Service)

        public IActionResult CreateEvent(EventViewModel eventViewModel)
        {

            using (IEventService ies = new EventService(new DataBaseContext()))




            {

                if (!ModelState.IsValid)
                {
                    foreach (var field in ModelState)
                    {
                        string fieldName = field.Key; // Nom du champ
                        var errors = field.Value.Errors; // Liste des erreurs associées

                        foreach (var error in errors)
                        {
                            Console.WriteLine($"Champ : {fieldName}, Erreur : {error.ErrorMessage}");
                        }
                    }
                }


                Console.WriteLine("vérification du model state de la création d'event " + ModelState.IsValid);
                if (ModelState.IsValid && ies.searchEvent(eventViewModel.Event.Id) == null)
                {
                    ies.CreateEvent(eventViewModel.Event.TypeEvent, eventViewModel.Event.NameEvent, eventViewModel.Event.StartEvent, eventViewModel.Event.EndEvent, eventViewModel.Event.Adress, eventViewModel.Event.Artist, eventViewModel.Event.Ticket, eventViewModel.Event.Service);
                    Console.WriteLine("Création" + eventViewModel.Event.ToString());
                }
                return View();
            }
        }
    }
}
