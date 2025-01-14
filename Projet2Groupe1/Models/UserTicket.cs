namespace Projet2Groupe1.Models
{
    //table de jonction entre ticket, event et user
    public class UserTicket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int BilletterieId { get; set; }
        public int EventId { get; set; }
        public int Quantity { get; set; }

    }
}
