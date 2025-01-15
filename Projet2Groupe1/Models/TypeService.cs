using System.ComponentModel.DataAnnotations;

namespace Projet2Groupe1.Models
{
    public enum TypeService
    {
        [Display(Name = "Restauration")]
        FOOD,

        [Display(Name = "Service de securite")]
        SECURITY,

        [Display(Name = "Montage/Demontage")]
        ASSEMBLY
    }
}
