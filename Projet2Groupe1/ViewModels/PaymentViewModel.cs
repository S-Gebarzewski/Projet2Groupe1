namespace Projet2Groupe1.ViewModels
{
    public class PaymentViewModel
    {
        public int CreditCardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public int VerificationNumber { get; set; }
        public string CardHolder { get; set; }
        public int MemberId { get; set; }
        //info de paiement + datavalidation
    }
}