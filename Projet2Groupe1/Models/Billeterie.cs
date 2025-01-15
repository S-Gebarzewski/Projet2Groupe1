namespace Projet2Groupe1.Models
{
    public class Billeterie
    {
        public int Id { get; set; }

        public int EventId { get; set; }
        public string Category { get; set; }
        public int NumberTotalTicket { get; set; }
        public int UnitPriceTicket { get; set; }
    }
}
