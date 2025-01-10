using Microsoft.AspNetCore.Mvc;
using Projet2Groupe1.Models;
using Projet2Groupe1.ViewModels;

namespace Projet2Groupe1.Controllers
{
    public class PaiementController : Controller
    {
        [HttpGet]
        public IActionResult Paiement()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Paiement(PaiementViewModel Paiement)
        {
            using (IMemberService ims = new MemberService(new DataBaseContext())) 
            { 
                Member Member = ims.GetMember(Paiement.MemberId);
                Member.IsPayed = true;
                Member UpdatedMember = ims.UpdateMember(Member);
                Console.WriteLine("Le Member avant modification : " + Member.ToString());
                Console.WriteLine("Le Member apres modification : " + UpdatedMember.ToString());
            }
                Console.WriteLine("Apres paiement valide - memberId vaut :" + Paiement.MemberId);
            return View("Login/Connection");
        }
    }
}
