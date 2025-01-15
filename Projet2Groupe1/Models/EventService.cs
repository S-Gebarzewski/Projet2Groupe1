
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
        
        public int CreateEvent(TypeEvent TypeEvent, string NameEvent, DateTime StartEvent, DateTime EndEvent, Adress? AdressData, Artist? Artist, Billeterie? billeterie, statusRegistration StatusRegistration,TypeService TypeService, int QuantityService, int userId)
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

            Billeterie Billeterie = new Billeterie()
            {
                Category = billeterie.Category,
                NumberTotalTicket = billeterie.NumberTotalTicket,
                UnitPriceTicket = billeterie.UnitPriceTicket
               
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
                Billetterie = Billeterie,
                userId = userId,
                TypeService = TypeService,
                QuantityService = QuantityService,
                StatusRegistration = StatusRegistration
            };

            _dbContext.Events.Add(newEvent);
            _dbContext.SaveChanges();

            return newEvent.Id;
        }


        //public int CreateEvent(TypeEvent TypeEvent, string NameEvent, DateTime StartEvent, DateTime EndEvent, Adress? Adress, Artist? Artist, Billeterie? Ticket, Service? Service, int userId, statusRegistration StatusRegistration)
        //{

        //    Event newEvent = new Event()
        //    {
        //        TypeEvent = TypeEvent,
        //        NameEvent = NameEvent,
        //        StartEvent = StartEvent,
        //        EndEvent = EndEvent,


        //        Adress = Adress,
        //        Artist = Artist,
        //        Billetterie = Ticket,
        //        Service = Service,
        //        userId = userId,
        //        StatusRegistration = StatusRegistration
        //    };

        //    _dbContext.Events.Add(newEvent);
        //    _dbContext.SaveChanges();

        //    return newEvent.Id;
        //}

        public Event searchEvent(int id)
        {
            return _dbContext.Events
             .Include(e => e.Artist)
             .Include(e => e.Adress)
             .Include(e => e.Billetterie)
             .FirstOrDefault(e => e.Id == id);
        }
        public int UpdateEvent(int Id, TypeEvent TypeEvent, string NameEvent, DateTime StartEvent, DateTime EndEvent, Adress? Adress, string NickNameArtist, Billeterie Billeterie,  TypeService TypeService)
        {
            Event newEvent = _dbContext.Events.Find(Id);

            if (newEvent != null)
            {
                newEvent.TypeEvent = TypeEvent;
                newEvent.NameEvent = NameEvent;
                newEvent.StartEvent = StartEvent;
                newEvent.EndEvent = EndEvent;
                newEvent.Adress = Adress;
                newEvent.Artist.NickNameArtist = NickNameArtist;
                newEvent.Billetterie = Billeterie;
                newEvent.TypeService = TypeService;
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
            return _dbContext.Events
        .Include(e =>e.Artist)
        .Include(e => e.Adress)
        .Include(e => e.Billetterie).
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
            return _dbContext.Events.Where(e => e.StatusRegistration == statusRegistration.ACCEPTED)
                .Include(e => e.Adress)
                .Include(e => e.Artist)
                .Include(e => e.Billetterie)
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
