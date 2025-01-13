
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
        
        public int CreateEvent(TypeEvent TypeEvent, string NameEvent, DateTime StartEvent, DateTime EndEvent, Adress? AdressData, Artist? Artist, Ticket? Ticket, Service? Service, statusRegistration StatusRegistration)
        { 
            Adress adress = new Adress()
            {
                ZipCode = AdressData.ZipCode,
                City = AdressData.City,
                StreetName = AdressData.StreetName,
                StreetNumber = AdressData.StreetNumber,
                NamedPlace = AdressData.NamedPlace,
                StreetComplement = AdressData.StreetComplement
            };

            Ticket ticket = new Ticket()
            {
                Category = Ticket.Category,
                NumberTotalTicket = Ticket.NumberTotalTicket,
                UnitPriceTicket = Ticket.UnitPriceTicket
               
            };

            Artist artist = new Artist()
            {
                FirstNameArtist = Artist.FirstNameArtist,
                LastNameArtist = Artist.LastNameArtist,
                NickNameArtist = Artist.NickNameArtist
            };
            Event newEvent = new Event()
            {
                TypeEvent = TypeEvent,
                NameEvent = NameEvent,
                StartEvent = StartEvent,
                EndEvent = EndEvent,
                Adress = adress,
                Artist = artist,
                Ticket = ticket,
                Service = Service,
                StatusRegistration = StatusRegistration
            };

            _dbContext.Events.Add(newEvent);
            _dbContext.SaveChanges();

            return newEvent.Id;
        }


        public int CreateEvent(TypeEvent TypeEvent, string NameEvent, DateTime StartEvent, DateTime EndEvent, Adress? Adress, Artist? Artist, Ticket? Ticket, Service? Service, int userId, statusRegistration StatusRegistration)
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
                userId = userId,
                StatusRegistration = StatusRegistration
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

        // Recupere un user, reecris toutes ses informations et
        // l'enregsitre avec ses nouvelles informations
        public Event UpdateEventStatus(Event UpdatingEvent)
        {
            Event ExistingEvent = GetEvent(UpdatingEvent.Id);

            ExistingEvent.StatusRegistration = UpdatingEvent.StatusRegistration;

            _dbContext.Events.Update(ExistingEvent);
            _dbContext.SaveChanges();

            return ExistingEvent;
        }

        

        public Event GetEvent(int id) 
        {
            return _dbContext.Events.Find(id);
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


        public List<Event> GetAllEvents()
        {
            return _dbContext.Events
                .Include(e => e.Adress)
                .Include(e => e.Artist)
                .Include(e => e.Ticket)
                .ToList();
        }

        public List<Event> GetFilteredEvents(string category = null, string city = null, string search = null)
        {
            List<Event> events = GetAllEvents();

            if(category != null)
            {
                events = events.Where(e => e.TypeEvent.ToString() == category).ToList();
            }
            if(city != null)
            {
                events = events.Where(e => e.Adress.City == city).ToList();
            }
            if (search != null)
            {
                events = events.Where(e => 
                e.NameEvent.Contains(search, StringComparison.OrdinalIgnoreCase) ||
                e.Artist.NickNameArtist.Contains(search, StringComparison.OrdinalIgnoreCase) == true)
                    .ToList();
            }
            return events;
        }



        public void Dispose()
        {
            this._dbContext.Dispose();
        }


    }
}
