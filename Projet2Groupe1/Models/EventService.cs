
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;

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
                userId = userId
            };

            _dbContext.Events.Add(newEvent);

            _dbContext.SaveChanges();

            return newEvent.Id;
        }

        public Event searchEvent(int id)
        {
            return _dbContext.Events
             .Include(e => e.Artist) 
             .Include(e => e.Adress) 
             .Include(e => e.Ticket)
             .Include(e => e.Service)
             .FirstOrDefault(e => e.Id == id);
        }
        public int UpdateEvent(int Id, TypeEvent TypeEvent, string NameEvent, DateTime StartEvent, DateTime EndEvent, Adress? Adress, Artist? Artist, Ticket? Ticket, Service? Service)
        {
            Event newEvent = _dbContext.Events.Find(Id);

            if (newEvent != null)
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
            return _dbContext.Events.Include(e => e.Adress) // Include related Adress
        .Include(e => e.Artist) // Include other related entities as needed
        .Include(e => e.Adress)
        .Include(e => e.Ticket)
        .Include(e => e.Service).
        Where(e => e.userId == userId).ToList();
        }
        public void DeleteEvent(int id)
        {
            Event newEvent = _dbContext.Events.Find(id);

            if (newEvent != null)
            {
                _dbContext.Events.Remove(newEvent);
                _dbContext.SaveChanges();
            }
            else
            {
                Console.WriteLine("not found");
            }
        }


        public void Dispose()
        {
            this._dbContext.Dispose();
        }


    }
}
