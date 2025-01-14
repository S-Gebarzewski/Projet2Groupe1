namespace Projet2Groupe1.Models
{
    public class Event
    {

        public int Id { get; set; }
        public TypeEvent TypeEvent { get; set; }
        public string NameEvent { get; set; }
        public DateTime StartEvent { get; set; }
        public DateTime EndEvent { get; set; }
        public Adress? Adress { get; set; }

        //penser ajout depot image  ============================================================================================================

        public Artist Artist {  get; set; }

        public Billeterie? Billetterie { get; set; }

        public Service? Service { get; set; }

        public byte[]? PhotoData { get; set; }

        public statusRegistration StatusRegistration { get; set; }
        public int userId { get; set; }


        //[DataType(DataType.Time)]
        //public TimeSpan? EndTime { get; set; } // heure dde fin

        //new DateTime(2025, 2, 20),
        //new TimeSpan(20, 0, 0),
        //new TimeSpan(23, 59, 0),

    }

}