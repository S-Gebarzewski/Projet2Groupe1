namespace Projet2Groupe1.Models
{
    public interface IEventService : IDisposable
    {
        public int CreateEvent(TypeEvent TypeEvent, string NameEvent, DateTime StartEvent, DateTime EndEvent, Adress? AdressData, Artist? Artist, Billeterie? billeterie, statusRegistration StatusRegistration, TypeService TypeService, int QuantityService, int userId);

        public Event searchEvent(int id);
        public int UpdateEvent(int Id, TypeEvent TypeEvent, string NameEvent, DateTime StartEvent, DateTime EndEvent, Adress? Adress, string NickNameArtist, Billeterie Billeterie, TypeService TypeService);

        public List<Event> searchEventList(int userId);
        public void DeleteEvent(int id);
        public List<Event> GetAllEvents();
        public Event UpdateEventStatus(Event UpdatingEvent);
        public List<Event> GetFilteredEvents(string category = null, string city = null, string search = null);

        public string GetDisplayName(Enum value);


        //pensez à ajouter le depot d'image =================================================================================================================
    }
}