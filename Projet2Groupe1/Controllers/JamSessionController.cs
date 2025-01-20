using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Projet2Groupe1.Models;
using Projet2Groupe1.ViewModels;

namespace Projet2Groupe1.Controllers
{
    public class JamSessionController : Controller

    {
        [HttpGet]
        public IActionResult CreateJamSession()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateJamSession(JamSessionViewModel jamSessionViewModel)
        {
            using (IJamService ijs = new JamService(new DataBaseContext()))
            {

                Console.WriteLine("vérification du model state de la création du jam " + ModelState.IsValid);
             
                    String userId = retrieveUserIdFromContext();
                    if (userId != null)
                    {
                    var fileService = new FileService();
                    string imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images/defaut-sessionJam.jpg");
                    byte[] fileByteArray = System.IO.File.ReadAllBytes(imagePath);
                    int jamSessionId = ijs.CreateJamSession(jamSessionViewModel.JamSession.Title, jamSessionViewModel.JamSession.StartSession, jamSessionViewModel.JamSession.EndSession, jamSessionViewModel.JamSession.Description, jamSessionViewModel.JamSession.NumberPlaces, jamSessionViewModel.JamSession.Instruments, jamSessionViewModel.JamSession.Adress, int.Parse(userId));
                        Console.WriteLine("Création" + jamSessionViewModel.JamSession.ToString());

                        return RedirectToAction("CatalogJamSession", new { id = jamSessionId });
                    }
                    else
                    {
                        Console.WriteLine("Erreur Création Jam userId : " + userId);
                    }
                
                return View();

            }
        }
        [HttpGet]
        public IActionResult CatalogJamSession()
        {
            using (IJamService ijs = new JamService(new DataBaseContext()))
            {
                List<JamSession> JamSessions = ijs.GetJamSessions();
                
                return View(JamSessions);

            };

           
        }
        [HttpGet]
        public IActionResult DeleteJamSession(JamSessionViewModel jamSessionViewModel)
        {
            using (IJamService ijs = new JamService(new DataBaseContext()))
            {
                string user_id = retrieveUserIdFromContext();
                jamSessionViewModel.JamSessions = ijs.searchJamSessionList(int.Parse(user_id));

                return View(jamSessionViewModel);
            };

        }
        [HttpPost]
        public IActionResult DeleteJamSessions(JamSessionViewModel jamSessionViewModel)
        {
            using (IJamService ijs = new JamService(new DataBaseContext()))
            {

                 ijs.DeleteJamSession(jamSessionViewModel.JamSession.Id);
                
            


            };

            return RedirectToAction("DeleteJamSession", jamSessionViewModel);
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
    }
}
