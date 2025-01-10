namespace Projet2Groupe1.Models
{
    public interface IEventService : IDisposable
    {
        public int CreateEvent(TypeEvent TypeEvent, string NameEvent, DateTime StartEvent, DateTime EndEvent, Adress Adress, Artist Artist, Ticket Ticket, Service Service);

        public Event searchEvent(int id);

        //pensez à ajouter le depot d'image =================================================================================================================
    }
}