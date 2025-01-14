using Microsoft.EntityFrameworkCore;

namespace Projet2Groupe1.Models
{
    public interface IJamService : IDisposable
    {
        public int CreateJamSession(string Title, DateTime StartSession, DateTime EndSession, string Description, int NumberPlaces, string Instruments,Adress? Adress, byte[]Photo,int userId);
        public JamSession searchJamSession(int id);
        public List<JamSession> GetJamSessions();
        public List<JamSession> searchJamSessionList(int userId);
        public void DeleteJamSession(int id);



    }
}
