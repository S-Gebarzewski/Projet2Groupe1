using System.ComponentModel.DataAnnotations;
using System.Net.Sockets;
using Projet2Groupe1.Models;

namespace Projet2Groupe1.ViewModels
{
    public class PaymentViewModel
    {
        [Required(ErrorMessage = "Le numéro de carte de crédit est obligatoire.")]
        [CreditCard(ErrorMessage = "Le numéro de carte de crédit est invalide.")]
        public string CreditCardNumber { get; set; }

        [Required(ErrorMessage = "La date d'expiration est obligatoire.")]
        [RegularExpression(@"^(0[1-9]|1[0-2])\/([0-9]{2})$", ErrorMessage = "La date d'expiration doit être au format MM/yy.")]
        [Display(Name = "Date d'expiration")]
        public string ExpirationDate { get; set; }

        [Required(ErrorMessage = "Le code de vérification est obligatoire.")]
        [Range(100, 999, ErrorMessage = "Le code de vérification doit contenir 3.")]
        [Display(Name = "Code de vérification")]
        public int VerificationNumber { get; set; }

        [Required(ErrorMessage = "Le nom du titulaire de la carte est obligatoire.")]
        [StringLength(100, ErrorMessage = "Le nom ne peut pas dépasser 100 caractères.")]
        public string CardHolder { get; set; }

        public int MemberId { get; set; }
        public UserTicket? Ticket { get; set; }
    }
}
