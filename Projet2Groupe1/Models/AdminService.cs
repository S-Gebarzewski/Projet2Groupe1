namespace Projet2Groupe1.Models
{
    public class AdminService : IAdminService
    {
        private DataBaseContext _dbContext;

        public AdminService(DataBaseContext _dbContext) 
        {
            this._dbContext = _dbContext;
        }
        public List<User> GetUsersByStatus(statusRegistration StatusRegistration, UserRole Role) 
        {
            List<User> FilteredUsersByStatus = _dbContext.Users.Where(u => u.StatusRegistration == StatusRegistration && u.Role == Role).ToList();
            Console.WriteLine($"{FilteredUsersByStatus.Count} users found for {StatusRegistration} and {Role}");
            return FilteredUsersByStatus;
        }

        public List<Event> GetEventsByStatus(statusRegistration StatusRegistration)
        {
            List<Event> FilteredEventsByStatus = _dbContext.Events.Where(u => u.StatusRegistration == StatusRegistration).ToList();
            Console.WriteLine($"{FilteredEventsByStatus.Count} events found for {StatusRegistration}");
            return FilteredEventsByStatus;
        }

        public int CreateAdmin(LevelAdmin LevelAdmin, int UserId)
        {
            Admin admin = new Admin()
            {
                LevelAdmin = LevelAdmin,
                UserId = UserId,
            };

            _dbContext.Admins.Add(admin);
            _dbContext.SaveChanges();
            return admin.Id;
        }

        //Recupere une l'id String depuis l'URL
        //et fait une recuperation en BDD du member correspondant
        public Admin GetAdmin(int id)
        {
            return _dbContext.Admins.Find(id);
        }

        //Recupere un id de type String depuis l'URL
        //et le tranforme em type int et relance GetMember avec un int
        public Admin GetAdmin(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.GetAdmin(id);
            }
            return null;
        }

        public Admin UpdateAdmin(Admin UpdatingAdmin) 
        {
            throw new NotImplementedException();
        }

        public Admin searchAdmin(int id)
        {
            return _dbContext.Admins.FirstOrDefault(s => s.Id == id);
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }
    }
}
