using System.ComponentModel.DataAnnotations;

namespace Projet2Groupe1.ViewModels
{
    public class PaymentViewModel
    {
        [Required(ErrorMessage = "Le numéro de carte de crédit est obligatoire.")]
        [CreditCard(ErrorMessage = "Le numéro de carte de crédit est invalide.")]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "La date d'expiration est obligatoire.")]
        [DataType(DataType.Date, ErrorMessage = "La date d'expiration doit être une date valide.")]
        [Display(Name = "Date d'expiration")]
        public DateTime ExpirationDate { get; set; }

        [Required(ErrorMessage = "Le code de vérification est obligatoire.")]
        [Range(100, 999, ErrorMessage = "Le code de vérification doit contenir 3.")]
        [Display(Name = "Code de vérification")]
        public int VerificationNumber { get; set; }

        [Required(ErrorMessage = "Le nom du titulaire de la carte est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères.")]
        public string CardHolder { get; set; }

        public int MemberId { get; set; }
    }
}