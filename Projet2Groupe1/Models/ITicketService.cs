using Humanizer.Localisation.TimeToClockNotation;

namespace Projet2Groupe1.Models
{
    public interface ITicketService : IDisposable
    {
        public int CreateTicket(int billetterieId, int eventiD, int userId, int quantity);
        public Billeterie GetBilletterieByEventId (int billetterieId);
        public bool BuyTicket ( int numberTicket, int eventId);
        
        public List<UserTicket> GetTicketsByUserId(int userID);

    }
}
