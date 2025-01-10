using Microsoft.AspNetCore.Mvc;
using Projet2Groupe1.Models;
using Projet2Groupe1.ViewModels;
using Newtonsoft.Json;
using Projet2Groupe1.Models;


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

        public IActionResult Index() //route GET pour ajouter un User avec une image
        {
            FileService fileService = new FileService();

            return View(fileService.GetEvents());
        }

        [HttpPost]
        public void SaveFile(EventFileUpload fileObj) //route POST pour récupérer un User avec une image
        {
            FileService fileService = new FileService();

            Event eventItem = JsonConvert.DeserializeObject<Event>(fileObj.EventId);

            if (fileObj.EventPicture.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    fileObj.EventPicture.CopyTo(ms);
                    byte[] fileBytes = ms.ToArray();
                    eventItem.PhotoData = fileBytes;

                    eventItem = fileService.AddEvent(eventItem);
                }
            }
        }

        public IActionResult AllEvents() // Route GET pour afficher l'ensemble des Users ajoutés
        {
            FileService fileService = new FileService();

            return View(fileService.GetEvents());
        }

    }
}

