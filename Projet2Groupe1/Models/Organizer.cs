using System.ComponentModel.DataAnnotations;

namespace Projet2Groupe1.Models
{
    public class Organizer
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "La fonction est obligatoire.")]
        [StringLength(100, ErrorMessage = "La fonction ne peut pas dépasser 100 caractères.")]
        public  string Function { get; set; }
        [Required(ErrorMessage = "La dénomination sociale est obligatoire.")]
        [StringLength(200, ErrorMessage = "La dénomination sociale ne peut pas dépasser 200 caractères.")]
        public string Denomination { get; set; }
        [Required(ErrorMessage = "Le RIB est obligatoire.")]
        [RegularExpression(@"^[0-9A-Za-z]{27}$", ErrorMessage = "Le RIB doit comporter exactement 27 caractères alphanumériques.")]
        public string RIB { get; set; }
        
        public  Adress? Adress { get; set; }
        public int UserId {  get; set; }
        //String file = "C:\\Users\\Naciim\\Desktop\\Isika\\.NET\\Projet2Groupe1\\Projet2Groupe1\\wwwroot\\Documents\";
        public byte[]? PhotoData { get; set; }

    }
}
