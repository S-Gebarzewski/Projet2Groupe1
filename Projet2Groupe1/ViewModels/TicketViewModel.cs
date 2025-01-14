using Projet2Groupe1.Models;

namespace Projet2Groupe1.ViewModels
{
    public class TicketViewModel
    {
        public Billeterie Billetterie { get; set; }

        public Event Event { get; set; }

        public User User { get; set; }

       
        public int TicketQuantityAvailable { get; set; }

    }
}
