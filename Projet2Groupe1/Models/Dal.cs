using Microsoft.EntityFrameworkCore;

namespace Projet2Groupe1.Models
{
    public class Dal : IDal
    {
        private DataBaseContext _dbContext;
        private UserService _userService;
        private OrganizerService _organizerService;
        private EventService _eventService;

        public Dal () 
        {
            _dbContext = new DataBaseContext();
            _userService = new UserService(_dbContext);
            _organizerService = new OrganizerService(_dbContext);
            _eventService = new EventService(_dbContext);   
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
            _organizerService.CreateOrganizer("PDG", "Les Jeux de Wacim", "XXXAAXXXAAXXXAAXXXAATRTTUHX", null, 5);
            Artist artist = new Artist
            {
                Id = 1,
                FirstNameArtist = "John",
                LastNameArtist = "Doe",
                NickNameArtist = "Johnny D"
            };
            Adress adress = new Adress
            {
                ZipCode = 75001,
                City = "Paris",
                StreetNumber = 12,
                StreetName = "Rue de Rivoli",
                NamedPlace = "Louvre Museum",
                StreetComplement = "Near the pyramid"
            };
            Ticket ticket = new Ticket 
              {

                    Category = "VIP",
                    NumberTotalTicket = 100,
                    UnitPriceTicket = 150
                };
            Service service = new Service
            {
              
                NameService = "Transportation",
                TypeService = "Logistics",
                QuantityService = 15
            };
            _eventService.CreateEvent(TypeEvent.CONCERT, "Concert Linkin Park", DateTime.Now, DateTime.Now.AddHours(3), 
                adress, artist, ticket, service,1);
            
            

        }
    }
}
