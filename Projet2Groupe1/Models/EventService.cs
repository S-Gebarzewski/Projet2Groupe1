
using System.Net.Sockets;

namespace Projet2Groupe1.Models
{
    public class EventService : IEventService
    {
        private DataBaseContext _dbContext;

        public EventService(DataBaseContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public int CreateEvent(TypeEvent TypeEvent, string NameEvent, DateTime StartEvent, DateTime EndEvent, Adress? Adress, Artist? Artist, Ticket? Ticket, Service? Service)
        {
            Event newEvent = new Event()
            {
                TypeEvent = TypeEvent,
                NameEvent = NameEvent,
                StartEvent = StartEvent,
                EndEvent = EndEvent,
                Adress = Adress,
                Artist = Artist,
                Ticket = Ticket,
                Service = Service
            };

            _dbContext.Events.Add(newEvent);

            _dbContext.SaveChanges();

            return newEvent.Id;
        }

        public Event searchEvent(int id)
        {
            return _dbContext.Events.FirstOrDefault(e => e.Id == id);
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }
    }
}
