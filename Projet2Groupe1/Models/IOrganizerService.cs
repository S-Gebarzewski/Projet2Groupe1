namespace Projet2Groupe1.Models
{
    public interface IOrganizerService : IDisposable
    {

        public int CreateOrganizer(string Function, string Denomination, string RIB, Adress Adress,int UserId);
        public User searchOrganizer(int id);
        public User ObtainOrganizer(int id);
        
    }
}
