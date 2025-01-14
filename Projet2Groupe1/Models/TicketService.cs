namespace Projet2Groupe1.Models
{
    public class TicketService : ITicketService
    {

        private DataBaseContext _dbContext;
        public TicketService(DataBaseContext _dbContext)
        {
            this._dbContext = _dbContext;
        }


        public bool BuyTicket(int numberTicket, int eventId)
        {
            Billeterie billeterie = GetBilletterieByEventId(eventId);
            if (billeterie != null)
            {
                if (billeterie.NumberTotalTicket >= numberTicket )
                    
                {
                    billeterie.NumberTotalTicket -= numberTicket;
                    _dbContext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
           
        }

        public int CreateTicket(int billetterieId, int eventiD, int userId, int quantity)
        {
            UserTicket userTicket = new UserTicket
            {
                BilletterieId = billetterieId,
                EventId = eventiD,
                UserId = userId,
                Quantity = quantity
            };
            _dbContext.UserTickets.Add(userTicket);
            _dbContext.SaveChanges();
            return userTicket.Id;
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }

        public Billeterie GetBilletterieByEventId(int eventId)
        {
            return _dbContext.Billetteries.FirstOrDefault(t => t.Id == eventId);
        }


        public bool TicketAvailable()
        {
            throw new NotImplementedException();
             
        }

       
    }
}
