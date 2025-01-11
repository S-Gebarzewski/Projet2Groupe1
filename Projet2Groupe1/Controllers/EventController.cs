using Microsoft.AspNetCore.Mvc;
using Projet2Groupe1.Models;
using Projet2Groupe1.ViewModels;
using Newtonsoft.Json;
using Projet2Groupe1.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using Microsoft.Extensions.Configuration.UserSecrets;


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
                    // Retrieve the ClaimsPrincipal from HttpContext
                    var userPrincipal = HttpContext.User;

                    // Get all ClaimsIdentities associated with the user
                    var identities = userPrincipal.Identities;

                    // If you know there's only one identity or want the first one
                    var claimIdentity = userPrincipal.Identity as ClaimsIdentity;
                    String userId = null;
                    // Retrieve the user.Id value from the Name claim
                    if (claimIdentity != null)
                    {
                        var userIdClaim = claimIdentity.FindFirst(ClaimTypes.Name);
                        if (userIdClaim != null)
                        {
                            userId = userIdClaim.Value; // This is the user.Id value
                            Console.WriteLine($"User ID: {userId}");
                        }
                        else
                        {
                            Console.WriteLine("User ID claim not found.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("No ClaimsIdentity found.");
                    }

                    int eventId = ies.CreateEvent(eventViewModel.Event.TypeEvent, eventViewModel.Event.NameEvent, eventViewModel.Event.StartEvent, eventViewModel.Event.EndEvent, eventViewModel.Event.Adress, eventViewModel.Event.Artist, eventViewModel.Event.Ticket, eventViewModel.Event.Service, int.Parse(userId));
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


        [HttpGet]
        public IActionResult UpdateEvent(EventViewModel eventViewModel)
        {
            using (IEventService ies = new EventService(new DataBaseContext()))
            {
                string user_id = HttpContext.Session.GetString("user_id");
                eventViewModel.Events = ies.searchEventList(int.Parse(user_id));
                eventViewModel.Events.ForEach(e =>
                {
                    Console.WriteLine("TEST evenement recupéré: " + e.NameEvent);
                });

                return View(eventViewModel);
            };

        }

        [HttpPost]
        public IActionResult UpdateEvents(EventViewModel eventViewModel)
        {
            using (IEventService ies = new EventService(new DataBaseContext()))
            {
                Console.WriteLine("requete de modification d'evenementssssssssssssssss" + eventViewModel);

                //ies.UpdateEvent( eventViewModel.Event.Id,eventViewModel.Event.TypeEvent, eventViewModel.Event.NameEvent, eventViewModel.Event.StartEvent, eventViewModel.Event.EndEvent, eventViewModel.Event.Adress, eventViewModel.Event.Artist, eventViewModel.Event.Ticket, eventViewModel.Event.Service);

            };


            return View(eventViewModel);
        }
 //       public IActionResult Details(int id)
 //       {
 //           var eventDetails = _dbcontext.Events
 //.Include(e => e.Organizer)
 //.FirstOrDefault(e => e.Id == id);
 //           if (eventDetails == null)
 //           {
 //               return NotFound();
 //           }

 //           return View(eventDetails);


        
    } 
}


