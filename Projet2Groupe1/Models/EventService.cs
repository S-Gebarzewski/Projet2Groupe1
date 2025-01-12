
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

        public int CreateEvent(TypeEvent TypeEvent, string NameEvent, DateTime StartEvent, DateTime EndEvent, Adress? AdressData, Artist? Artist, Ticket? Ticket, Service? Service)
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
