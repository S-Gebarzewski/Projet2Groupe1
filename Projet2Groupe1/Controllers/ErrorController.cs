using Microsoft.AspNetCore.Mvc;
using Projet2Groupe1.ViewModels;

namespace Projet2Groupe1.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Error(int errorCode, string message)
        {
            ErrorViewModel Error = new ErrorViewModel
            {
                ErrorCode = errorCode,
                Message = message
            };

            return View(Error);
        }


    }
}
