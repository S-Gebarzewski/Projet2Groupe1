using System.ComponentModel.DataAnnotations;

namespace Projet2Groupe1.Models
{
    public class JamSession
    {
        public int Id { get; set; }
       
        public string? Title { get; set; }
    
        public DateTime StartSession { get; set; }
      
        public DateTime EndSession { get; set; }
      
        public string? Description { get; set; }
        public int NumberPlaces { get; set; }   
      
        public string? Instruments { get; set; } 
        public  Adress? Adress { get; set; }
        public byte[]? Photo{ get; set; }

        public int userId{ get; set; }
            
        public override string ToString()
        {
            return $"Session de Jam : {Title}, créée par le membre {userId}, du {StartSession} au {EndSession}.";
        }
    }
}

