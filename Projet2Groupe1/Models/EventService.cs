
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

        public int CreateEvent(TypeEvent TypeEvent, string NameEvent, DateTime StartEvent, DateTime EndEvent, Adress? Adress, Artist? Artist, Ticket? Ticket, Service? Service, int userId)
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
                Service = Service,
                userId= userId
            };

            _dbContext.Events.Add(newEvent);

            _dbContext.SaveChanges();

            return newEvent.Id;
        }

        public Event searchEvent(int id)
        {
            return _dbContext.Events.FirstOrDefault(e => e.Id == id);
        }
        public int UpdateEvent(int Id,TypeEvent TypeEvent, string NameEvent, DateTime StartEvent, DateTime EndEvent, Adress? Adress, Artist? Artist, Ticket? Ticket, Service? Service)
        {
            Event newEvent = _dbContext.Events.Find(Id);

            if (newEvent!= null)
            {
                newEvent.TypeEvent = TypeEvent;
                newEvent.NameEvent = NameEvent;
                newEvent.StartEvent = StartEvent;
                newEvent.EndEvent = EndEvent;
                newEvent.Adress = Adress;
                newEvent.Artist = Artist;
                newEvent.Ticket = Ticket;
                newEvent.Service = Service;
                _dbContext.SaveChanges();
            }
            return newEvent.Id;

        }

        public List<Event> searchEventList(int userId)
        {
            return _dbContext.Events.Where(e=>e.userId== userId).ToList();
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }
    }
}
