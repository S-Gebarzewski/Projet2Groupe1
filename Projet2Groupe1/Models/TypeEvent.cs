using System.ComponentModel.DataAnnotations;

namespace Projet2Groupe1.Models
{
    public enum TypeEvent
    {
        [Display(Name = "Concert")]
            CONCERT,
        [Display(Name = "Festival")]
            FESTIVAL,
        [Display(Name = "Séance de dédicaces")]
           SIGNINGSESSION
    }
}
