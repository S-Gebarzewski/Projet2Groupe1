namespace Projet2Groupe1.Models
{
    public class TicketService : ITicketService
    {

        private DataBaseContext _dbContext;
        public TicketService(DataBaseContext _dbContext)
        {
            this._dbContext = _dbContext;
        }


        public int BuyTicket(int numberTicket)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }

        public Ticket GetTicketById(int ticketId)
        {
            return _dbContext.Tickets.FirstOrDefault(t => t.Id == ticketId);
        }

        //public Ticket GetTicketByIdEvent(int eventId)
        //{
        //    return _dbContext.Tickets.
        //}

        public bool TicketAvailable()
        {
            throw new NotImplementedException();
             
        }

       
    }
}
