namespace Projet2Groupe1.Models
{
    public class JamService : IJamService
    {
        private DataBaseContext _dbContext;

        public JamService(DataBaseContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public int CreateJamSession(string Title, DateTime StartSession, DateTime EndSession, string Description, int NumberPlaces, string Instruments,Adress Adress,byte[] Photo, int userId)
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
                Photo = Photo,    
                userId = userId



            };
            _dbContext.Sessions.Add(NewJamSession);

            _dbContext.SaveChanges();

            return NewJamSession.Id;

        }
        
    
   
     


        JamSession IJamService.searchEvent(int id)
        {
            return _dbContext.Sessions.FirstOrDefault(e => e.Id == id);
            
        }
        public void Dispose()
        {
            this._dbContext.Dispose();
        }

    }
}
    
