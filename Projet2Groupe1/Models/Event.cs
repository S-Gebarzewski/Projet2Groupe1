using System.ComponentModel.DataAnnotations;

namespace Projet2Groupe1.Models
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventType { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }

        //[DataType(DataType.Time)]
        //public TimeSpan? EndTime { get; set; } // heure dde fin

            //new DateTime(2025, 2, 20),
            //new TimeSpan(20, 0, 0),
            //new TimeSpan(23, 59, 0),

    }

}
