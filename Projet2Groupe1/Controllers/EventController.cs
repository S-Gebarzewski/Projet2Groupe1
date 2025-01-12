using Microsoft.AspNetCore.Mvc;
using Projet2Groupe1.Models;
using Projet2Groupe1.ViewModels;
using System.Security.Claims;


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

                Console.WriteLine("vérification du model state de la création d'event " + ModelState.IsValid);
                if (ModelState.IsValid && ies.searchEvent(eventViewModel.Event.Id) == null)
                {
                    String userId = retrieveUserIdFromContext();
                    if (userId != null)
                    {

                        ies.CreateEvent(eventViewModel.Event.TypeEvent, eventViewModel.Event.NameEvent, eventViewModel.Event.StartEvent, eventViewModel.Event.EndEvent, eventViewModel.Event.Adress, eventViewModel.Event.Artist, eventViewModel.Event.Ticket, eventViewModel.Event.Service, int.Parse(userId));
                        Console.WriteLine("Création" + eventViewModel.Event.ToString());
                    }
                    else
                    {
                        Console.WriteLine("Erreur Création Event userId : " + userId);
                    }
                }
                return View();
            }
        }

        private String retrieveUserIdFromContext()
        {
            var userPrincipal = HttpContext.User;

            ClaimsIdentity claimIdentity = (ClaimsIdentity)HttpContext.User.Identity;
            String userId = null;
            
            if (claimIdentity != null)
            {
                var userIdClaim = claimIdentity.FindFirst(ClaimTypes.Name);
                if (userIdClaim != null)
                {
                    userId = userIdClaim.Value; 
                }
            }

            return userId;
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
                string user_id = retrieveUserIdFromContext();
                eventViewModel.Events = ies.searchEventList(int.Parse(user_id));

                return View(eventViewModel);
            };

        }

        [HttpPost]
        public IActionResult UpdateEvents(EventViewModel eventViewModel)
        {
            using (IEventService ies = new EventService(new DataBaseContext()))
            {
               
                Event eventToUpdate = ies.searchEvent(eventViewModel.Event.Id);
                eventToUpdate.Artist.NickNameArtist = eventViewModel.Event.Artist.NickNameArtist;
                ies.UpdateEvent(eventToUpdate.Id, eventViewModel.Event.TypeEvent, eventViewModel.Event.NameEvent, eventViewModel.Event.StartEvent, eventViewModel.Event.EndEvent, eventToUpdate.Adress, eventToUpdate.Artist, eventToUpdate.Ticket, eventToUpdate.Service);

            };

            return RedirectToAction("UpdateEvent", eventViewModel);
        }

        [HttpPost]
        public IActionResult DeleteEvent(EventViewModel eventViewModel)
        {
            using (IEventService ies = new EventService(new DataBaseContext()))
            {
             
                ies.DeleteEvent(eventViewModel.Event.Id);
                

            }
            return RedirectToAction("UpdateEvent",eventViewModel);  

        }

 


        
    } 
}


