using Microsoft.AspNetCore.Mvc;
using Projet2Groupe1.ViewModels;

namespace Projet2Groupe1.Controllers
{
    public class PaiementController : Controller
    {
        [HttpGet]
        public IActionResult ValidationPaiement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ValidationPaiement(PaiementViewModel Paiement)
        {

            Console.WriteLine("Apres paiement valide - memberId vaut :" + Paiement.MemberId);
            return View();
        }
    }
}
