using Microsoft.EntityFrameworkCore;

namespace Projet2Groupe1.Models
{
    public interface IJamService : IDisposable
    {
        public int CreateJamSession(string Title, DateTime StartSession, DateTime EndSession, string Description, int NumberPlaces, string Instruments,Adress? Adress, byte[]Photo,int userId);
        public JamSession searchEvent(int id);
        public List<JamSession> GetJamSessions();



    }
}
