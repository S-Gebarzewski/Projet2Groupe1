using Microsoft.EntityFrameworkCore;

namespace Projet2Groupe1.Models
{
    public class JamService : IJamService
    {
        private DataBaseContext _dbContext;

        public JamService(DataBaseContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public int CreateJamSession(string Title, DateTime StartSession, DateTime EndSession, string Description, int NumberPlaces, string Instruments,Adress Adress, int userId)
        {
            JamSession NewJamSession = new JamSession()
            {
                Title = Title,
                StartSession = StartSession,
                EndSession = EndSession,
                Description = Description,
                NumberPlaces = NumberPlaces,
                Instruments = Instruments,
                Adress = Adress,    
                  
                userId = userId



            };
            _dbContext.Sessions.Add(NewJamSession);

            _dbContext.SaveChanges();

            return NewJamSession.Id;

        }

        public List<JamSession> GetJamSessions()
        {
            return this._dbContext.Sessions.Include(e => e.Adress).ToList();
        }
 public List<JamSession> searchJamSessionList(int userId)
        {
            return _dbContext.Sessions.Include(e => e.Adress).Where(e => e.userId == userId).ToList();
        }






        JamSession IJamService.searchJamSession(int id)
        {
            return _dbContext.Sessions.FirstOrDefault(e => e.Id == id);
            
        }
        public void DeleteJamSession(int id)
        {
            JamSession newJamSession = _dbContext.Sessions.Find(id);

            if (newJamSession != null)
            {
                _dbContext.Sessions.Remove(newJamSession);
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
    
