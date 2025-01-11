namespace Projet2Groupe1.Models
{
    public interface IEventService : IDisposable
    {
        public int CreateEvent(TypeEvent TypeEvent, string NameEvent, DateTime StartEvent, DateTime EndEvent, Adress Adress, Artist Artist, Ticket Ticket, Service Service, int userId);

        public Event searchEvent(int id);
        public int UpdateEvent(int id, TypeEvent TypeEvent, string NameEvent, DateTime StartEvent, DateTime EndEvent, Adress? Adress, Artist? Artist, Ticket? Ticket, Service? Service);

        public List<Event> searchEventList(int userId);


        //pensez à ajouter le depot d'image =================================================================================================================
    }
}