using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata;
using Projet2Groupe1.Models;
using Projet2Groupe1.ViewModels;

namespace Projet2Groupe1.Controllers
{
    public class PaymentController : Controller
    {
        [HttpGet]
        public IActionResult Payment()
        {

            using (IMemberService ims = new MemberService(new DataBaseContext()))

            using (IUserService ius = new UserService(new DataBaseContext()))
            {
                User user = null;
                if (TempData["userId"] == null) // dans le cas ou je me connecte a mon compte et je click sur devenir prémium
                {
                    user = ius.GetUser(HttpContext.User.Identity.Name);
                }
                else
                {
                    
                    user = ius.GetUser(int.Parse(TempData["userId"].ToString())); // dans le cas ou la demande est faites en cours de registration
                }

                Console.WriteLine("le user id est " + user.Id);
                if (user.Id != null)
                {
                    Member Member = ims.GetMemberByUserId(user.Id);
                    if (Member.Id != null)
                    {

                        Console.WriteLine("le member Id est " + Member.Id);
                        TempData["MemberId"] = Member.Id;
                    }
                    else
                    {
                        Console.WriteLine("Member est null");
                    }
                   
                }
                else
                {
                    Console.WriteLine("user est null");
                }
              
                return View();
            }
        }

        [HttpPost]
        public IActionResult Payment(PaymentViewModel Paiement)
        {
            if (Paiement == null)
            {
                Console.WriteLine("Le modèle Paiement est null !");
                return View("Error"); // Ou une autre vue appropriée
            }
            using (IMemberService ims = new MemberService(new DataBaseContext())) 
            { 
                Member Member = ims.GetMember(Paiement.MemberId);
                Console.WriteLine("Le Member avant modification : " + Member.ToString());
                Member.IsPayed = true;
                Member UpdatedMember = ims.UpdateMember(Member);
                
                Console.WriteLine("Le Member apres modification : " + UpdatedMember.ToString());

            }
                Console.WriteLine("Apres paiement valide - memberId vaut :" + Paiement.MemberId);
            return RedirectToAction("Connection", "Login");
        }
    }
}
