namespace Projet2Groupe1.Models
{
    public class Dal : IDal
    {
        private static DataBaseContext _dbContext;
        private UserService _userService;

        public static DataBaseContext getDbContext()
        {
            if (Dal._dbContext == null)
            {
                _dbContext = new DataBaseContext();
            }
            return _dbContext;

        }

        public Dal () 
        { 
            _userService = new UserService();
        }

        public void DeleteCreateDb()
        {
            getDbContext().Database.EnsureDeleted(); // suppression de la BDD
            getDbContext ().Database.EnsureCreated(); // creation de la BDD
        }

        // Ferme la connexion et libere les ressources utilises par l'objet quand ce n'est plus necessaire
        public void Dispose() 
        {
            getDbContext().Dispose();
        }

        public void InitializeDb()
        {
            _userService.CreateUser("Raven", "Ethevenaux", 0612121212, "RE@gmail.com", "croquette", UserRole.ADMIN);
            _userService.CreateUser("Pere", "Noel", 0836656565, "pere-noel@laposte.net", "chefLutin_KDO6", UserRole.PROVIDER);
        }
    }
}
