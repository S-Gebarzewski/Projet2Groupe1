using System.ComponentModel.DataAnnotations;
using System.Reflection.Metadata;

namespace Projet2Groupe1.Models
{
    public class Service
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Le nom du service est obligatoire.")]
        [MinLength(2, ErrorMessage = "Veuillez entrer un nom contenant au moins deux caracteres.")]
        public string NameService { get; set; }
        [Required(ErrorMessage = "Le type de service est obligatoire.")]
        public TypeService TypeService { get; set; }
        [Required(ErrorMessage = "Le nombre de service disponible proposes est obligatoire.")]
        public int QuantityService { get; set; }
        [Required(ErrorMessage = "Le description du service est obligatoire.")]
        [MaxLength(250, ErrorMessage = "La description ne doit pas faire plus de 250 caracteres.")]
        public string DescriptionService { get; set; } //
        [Required(ErrorMessage = "Le prix du service est obligatoire.")]
        public int PriceService { get; set; }
        //public Blob? PictureService { get; set; }
    }
}
