using System.ComponentModel.DataAnnotations;

namespace Projet2Groupe1.Models
{
    public class Member
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Veuillez preciser votre age.")]
        [Range(16, 130, ErrorMessage = "Vous devez avoir au moins 18 ans pour vous inscrire.")]
        public int? Age {  get; set; }
        [Required(ErrorMessage = "Veuillez entrer votre ville pour selectionner des evenements proches de chez vous.")]
        [MinLength(2)]
        public string City { get; set; }

        [Required(ErrorMessage = "Veuillez entrer votre code postal.")]
        [RegularExpression("^[0-9]+$", ErrorMessage = "Le code postal ne doit contenir que des chiffres.")]
        [StringLength(5, MinimumLength = 5, ErrorMessage = "Le code postal doit avoir le format : 01000.")]
        public string? ZipCode { get; set; }

        public bool IsPremium { get; set; }
        public int UserId { get; set; }

        public override String ToString()
        {
            return $"Creation d'un Member : {Age} ans {IsPremium}. Son UserId est : {UserId}";
        }
    }
}
