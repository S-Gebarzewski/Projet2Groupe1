﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Projet2Groupe1.Models;
using Projet2Groupe1.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using System.Security.Claims;


namespace Projet2Groupe1.Controllers
{
    public class EventController : Controller
    {


        public IActionResult Catalog(string category, string city, string search)
        {
            using (IEventService ies = new EventService(new DataBaseContext()))
            using (IUserService ius = new UserService(new DataBaseContext()))
            {
                Console.WriteLine("IsAuthenticated est a " + HttpContext.User.Identity.IsAuthenticated);
                UserViewModel uvm = new UserViewModel
                {
                    Authenticate = HttpContext.User.Identity.IsAuthenticated
                };
                ViewData["IsAuthenticated"] = uvm.Authenticate;
                uvm.User = ius.GetUser(HttpContext.User.Identity.Name);
                List<Event> events = ies.GetFilteredEvents(category, city, search);
                if (uvm.User == null)
                {
                    return View(events);
                }
                else
                {
                    ViewData["Role"] = uvm.User.Role;
                    return View(events);
                }
               
            };
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
                        statusRegistration StatusPending = statusRegistration.PENDING;
                                                                                   
                        int eventId = ies.CreateEvent(eventViewModel.Event.TypeEvent, eventViewModel.Event.NameEvent, eventViewModel.Event.StartEvent, eventViewModel.Event.EndEvent, eventViewModel.Event.Adress, eventViewModel.Event.Artist, eventViewModel.Event.Billetterie, StatusPending, eventViewModel.Event.TypeService,eventViewModel.Event.QuantityService ,int.Parse(userId) );
                        Console.WriteLine("Création" + eventViewModel.Event.ToString());
                        TempData["Role"] = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                        Console.WriteLine("Role est a " + TempData["Role"]);
                        return RedirectToAction("DetailsEvent", new { id = eventId });
                    }
                    else
                    {
                        Console.WriteLine("Erreur Création Event userId : " + userId);
                    }
                }
                return View();
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
                    TempData["Role"] = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
                    Console.WriteLine("Role est a " + TempData["Role"]);
                    return View(eventViewModel);
                }
                return RedirectToAction("CreateEvent", eventViewModel);
            }
        }
        public IActionResult GetDefaultImage(TypeEvent type)
        {
            var fileService = new FileService();
            string imagePath = fileService.GetDefaultImagePath(type);
            return File(imagePath, "image/png");
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
                Console.WriteLine("user Id vaut " + user_id);
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
                Console.WriteLine("on est dans la merde" + eventViewModel.Event.Artist.NickNameArtist);
                eventToUpdate.Artist.NickNameArtist = eventViewModel.Event.Artist.NickNameArtist;
                ies.UpdateEvent(eventToUpdate.Id, eventViewModel.Event.TypeEvent, eventViewModel.Event.NameEvent, eventViewModel.Event.StartEvent, eventViewModel.Event.EndEvent, eventToUpdate.Adress, eventToUpdate.Artist.NickNameArtist, eventToUpdate.Billetterie, eventToUpdate.TypeService);

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


