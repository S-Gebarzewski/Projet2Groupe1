using System.ComponentModel.DataAnnotations;

namespace Projet2Groupe1.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le prenom est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le prenom doit contenir au moins 2 caracteres.")]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "Le nom de famille est obligatoire.")]
        [MinLength(2, ErrorMessage = "Le nom de famille doit contenir au moins 2 caracteres.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Le numero de telephone est obligatoire.")]
        [RegularExpression(@"^0[1-9](\d{2}){4}$", ErrorMessage = "Veuillez entrer un numéro de téléphone valide au format français (ex : 0612345678).")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "L'adresse mail est obligatoire.")]
        [EmailAddress(ErrorMessage = "L'adresse mail doit avoir le format : exemple@exemple.com")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire.")]
        [RegularExpression("^[a-zA-Z!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~²³€£°§]{12,50}$", ErrorMessage = "Le mot de passe doit contenir au moins une majuscule, une minuscule et un caractere special.")]
        [StringLength(50, MinimumLength = 12, ErrorMessage = "Le mot de passe doit comprendre entre 12 et 20 caracteres.")]
        public string Password { get; set; }
        public bool Newsletter { get; set; }
    
        public UserRole Role { get; set; } // appel a mon enum 
      
        public byte[]? PhotoData { get; set; }
      

        public override String ToString()
        {
            return $"Creation d'un User : {FirstName} {LastName}. Son id est : {Id}";
        }
    }
}
