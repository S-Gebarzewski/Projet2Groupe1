
﻿using System.ComponentModel.DataAnnotations;

namespace Projet2Groupe1.Models
{ 

    public class Adress
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Le code postal est obligatoire.")]
        [RegularExpression(@"^\d{5}$", ErrorMessage = "Le code postal doit comporter  5 chiffres.")]
        public int ZipCode { get; set; }
        [Required(ErrorMessage = "La ville est obligatoire.")]
        [StringLength(100, ErrorMessage = "La ville ne peut pas dépasser 100 caractères.")]
        public string City { get; set; }
        [Required(ErrorMessage = "Le numéro de rue est obligatoire.")]
        public int StreetNumber { get; set; }
        [Required(ErrorMessage = "Le nom de la rue est obligatoire.")]
        public string StreetName { get; set; }
        
        public string? NamedPlace { get; set; }
        [Required(ErrorMessage = "Le complément d'adresse est obligatoire.")]
        public string? StreetComplement { get; set; }
        



    }
}
