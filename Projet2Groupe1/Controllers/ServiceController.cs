using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Microsoft.AspNetCore.Mvc;
using Projet2Groupe1.Models;

namespace Projet2Groupe1.Controllers
{
    public class ServiceController : Controller
    {
        [HttpGet]
        public IActionResult CreateService()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CreateService(Service Service)
        {
            Console.WriteLine("Je suis dans createService");
            using (IServiceService iss = new ServiceService(new DataBaseContext()))
            {
                int ServiceId = iss.CreateService(Service.NameService, Service.TypeService, Service.QuantityService, Service.DescriptionService, Service.PriceService);
                Console.WriteLine("J'ai cree le service. Son id est : " + ServiceId);
                return View();
            }
        }

        public IActionResult MyServices()
        {
            return View();
        }

        
    }
}
