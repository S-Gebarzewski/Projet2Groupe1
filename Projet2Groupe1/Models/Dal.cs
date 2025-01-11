using Microsoft.EntityFrameworkCore;

namespace Projet2Groupe1.Models
{
    public class Dal : IDal
    {
        private DataBaseContext _dbContext;
        private UserService _userService;

        public Dal () 
        {
            _dbContext = new DataBaseContext();
            _userService = new UserService(_dbContext);
        }

        public void DeleteCreateDb()
        {
            _dbContext.Database.EnsureDeleted(); // suppression de la BDD
            _dbContext.Database.EnsureCreated(); // creation de la BDD
        }

        // Ferme la connexion et libere les ressources utilises par l'objet quand ce n'est plus necessaire
        public void Dispose() 
        {
            _dbContext.Dispose();
        }

        public void InitializeDb()
        {
            _userService.CreateUser("Raven", "Ethevenaux", "0612121212", "RE@gmail.com", "croquette", true, UserRole.ADMIN);
            _userService.CreateUser("Pere", "Noel", "0836656565", "pere-noel@laposte.net", "chefLutin_KDO6", true, UserRole.PROVIDER);
            _userService.CreateUser("Manel","Merini","0661218022","MM@gmail.com","1234", true, UserRole.MEMBER);
            _userService.CreateUser("David", "Bisounours", "0781345676", "DB@gmail.com", "12345", true, UserRole.PREMIUM);
            _userService.CreateUser("Anthony", "Statek", "0328765439", "AS@gmail.com", "123", true, UserRole.ORGANIZER);
            _userService.CreateUser("Coleen", "Miclo", "0665432876", "CM@gmail.com", "12345", true, UserRole.PROVIDER);

            _userService.CreateUser("Admin", "ISIKA", "0450452356", "admin@gmail.com", "1234", true, UserRole.ADMIN);
            _userService.CreateUser("Organizer", "ISIKA", "0450452356", "organizer@gmail.com", "1234", true, UserRole.ORGANIZER);
            _userService.CreateUser("Provider", "ISIKA", "0450452356", "provider@gmail.com", "1234", true, UserRole.PROVIDER);
            _userService.CreateUser("Member", "ISIKA", "0450452356", "member@gmail.com", "1234", true, UserRole.MEMBER);
            _userService.CreateUser("Premium", "ISIKA", "0450452356", "premium@gmail.com", "1234", true, UserRole.PREMIUM);
        }
    }
}
