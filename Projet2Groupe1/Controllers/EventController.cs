using Microsoft.AspNetCore.Mvc;
using Projet2Groupe1.Models;
using Projet2Groupe1.ViewModels;
using Newtonsoft.Json;
using Projet2Groupe1.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;


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

        //public int CreateEvent(TypeEvent TypeEvent, string NameEvent, DateTime StartEvent, DateTime EndEvent, Adress Adress, Artist Artist, Ticket Ticket, Service Service)

        [HttpPost]
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

                    int eventId = ies.CreateEvent(eventViewModel.Event.TypeEvent, eventViewModel.Event.NameEvent, eventViewModel.Event.StartEvent, eventViewModel.Event.EndEvent, eventViewModel.Event.Adress, eventViewModel.Event.Artist, eventViewModel.Event.Ticket, eventViewModel.Event.Service);
                    Console.WriteLine("Création" + eventViewModel.Event.ToString());
                    // si l'event est enregistré on redirige vers la page de détails de l'even où il peut choisir l'image et je passe à cette vue l'id de l'event
                    return RedirectToAction("DetailsEvent", new { id = eventId });

                }
                //passer le event view model en paramètre permet de renvoyer le formulaire avec les données saisies
                return View(eventViewModel);
            }
        }

        //get pour afficher l'événement et le formulaire d'upload
        public IActionResult DetailsEvent(int id) //route GET pour ajouter un User avec une image
        {
            using (IEventService ies = new EventService(new DataBaseContext()))
            {
                Event eventItem = ies.searchEvent(id);

                EventViewModel eventViewModel = new EventViewModel();
                if (eventItem != null)
                {
                    {
                        eventViewModel.Event = eventItem;
                        
                    };
                    
                    return View(eventViewModel);
                }
                return RedirectToAction("CreateEvent",eventViewModel);
            }
        }
        public IActionResult GetDefaultImage(TypeEvent type)
        {
            var fileService = new FileService();
            string imagePath = fileService.GetDefaultImagePath(type);
            return File(imagePath, "image/png");
        }


        public IActionResult AllEvents() // Route GET pour afficher l'ensemble des Users ajoutés
        {
            FileService fileService = new FileService();

            return View(fileService.GetEvents());
        }

       

        //contrôleur reçoit le fichier, le convertit en bytes et le sauvegarde
        [HttpPost]
        public IActionResult SaveFile(EventFileUpload fileObj) //route POST pour récupérer un User avec une image
        {
            try
            {
                using (var fileService = new FileService())
                {
                    byte[] fileBytes = null;

                    //  Event eventItem = JsonConvert.DeserializeObject<Event>(fileObj.EventId);

                    // s'il y a déjà une image uploadée, on la récupère
                    if (fileObj.EventPicture != null && fileObj.EventPicture.Length > 0)
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            fileObj.EventPicture.CopyTo(ms);
                            //convertit le fichier uploder en bytes
                            fileBytes = ms.ToArray();

                        }
                   
                    }
                    fileService.SaveEventPicture(fileObj.EventId, fileBytes);
                    return Json(new { success = true, message = "Image uploadée avec succès" });

                }
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Erreur lors de l'upload: " + ex.Message });
            }
        }

    }
}