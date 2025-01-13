namespace Projet2Groupe1.Models
{
    public interface ITicketService : IDisposable
    {
        public Ticket GetTicketById (int ticketId);
        public bool TicketAvailable ();
        public int BuyTicket (int numberTicket);
        
        //public Ticket GetTicketByIdEvent (int eventId);
    }
}
