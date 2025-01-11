using Projet2Groupe1.Models;

namespace Projet2Groupe1.ViewModels
{
    public class EventViewModel
    {
        public Event Event { get; set; }

        public Adress? Adress {  get; set; }
        
        public Artist? Artist { get; set; }

        public Service? Service { get; set; }

        public Ticket? Ticket { get; set; }
        public TypeEvent TypeEvent { get; set; }

    }
}
