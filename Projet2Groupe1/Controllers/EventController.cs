using Microsoft.AspNetCore.Mvc;
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

