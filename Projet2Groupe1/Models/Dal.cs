using Microsoft.EntityFrameworkCore;

namespace Projet2Groupe1.Models
{
    public class Dal : IDal
    {
        private DataBaseContext _dbContext;
        private UserService _userService;
        private EventService _eventService;

        public Dal () 
        {
            _dbContext = new DataBaseContext();
            _userService = new UserService(_dbContext);
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

            var olympiaAddress = new Adress
            {
                StreetNumber = 28,
                StreetName = "Boulevard des Capucines",
                City = "Paris",
                ZipCode = 75009,
                NamedPlace = "L'Olympia",
                StreetComplement = null
            };

            var zenithAddress = new Adress
            {
                StreetNumber = 211,
                StreetName = "Avenue Jean-Jaurès",
                City = "Paris",
                ZipCode = 75019,
                NamedPlace = "Le Zénith",
                StreetComplement = null
            };

            var bercy = new Adress
            {
                StreetNumber = 8,
                StreetName = "Boulevard de Bercy",
                City = "Paris",
                ZipCode = 75012,
                NamedPlace = "Accor Arena",
                StreetComplement = null
            };

            // Création des artistes
            var orelsan = new Artist
            {
                FirstNameArtist = "Aurélien",
                LastNameArtist = "Cotentin",
                NickNameArtist = "Orelsan"
            };

            var bowie = new Artist
            {
                FirstNameArtist = "David",
                LastNameArtist = "Jones",
                NickNameArtist = "David Bowie"
            };

            var stromae = new Artist
            {
                FirstNameArtist = "Paul",
                LastNameArtist = "Van Haver",
                NickNameArtist = "Stromae"
            };

            var indochine = new Artist
            {
                FirstNameArtist = "Nicola",
                LastNameArtist = "Sirkis",
                NickNameArtist = "Indochine"
            };

            var iggyPop = new Artist
            {
                FirstNameArtist = "James",
                LastNameArtist = "Osterberg",
                NickNameArtist = "Iggy Pop"
            };

            // Création des tickets
            var ticketConcertStandard = new Ticket
            {
                Category = "Standard",
                NumberTotalTicket = 2000,
                UnitPriceTicket = 45
            };

            var ticketConcertVIP = new Ticket
            {
                Category = "VIP",
                NumberTotalTicket = 200,
                UnitPriceTicket = 120
            };

            var ticketFestival = new Ticket
            {
                Category = "Pass 3 jours",
                NumberTotalTicket = 5000,
                UnitPriceTicket = 150
            };

            // Création des événements
            _eventService.CreateEvent(
                TypeEvent.CONCERT,
                "Orelsan - Civilization Tour",
                DateTime.Parse("2025-03-15 20:00"),
                DateTime.Parse("2025-03-15 23:30"),
                bercy,
                orelsan,
                ticketConcertStandard,
                null
            );

            _eventService.CreateEvent(
                TypeEvent.CONCERT,
                "Stromae - Multitude Tour",
                DateTime.Parse("2025-04-20 20:00"),
                DateTime.Parse("2025-04-20 23:00"),
                olympiaAddress,
                stromae,
                ticketConcertVIP,
                null
            );

            _eventService.CreateEvent(
                TypeEvent.FESTIVAL,
                "Festival Solidays 2025",
                DateTime.Parse("2025-06-28 14:00"),
                DateTime.Parse("2025-06-30 23:59"),
                new Adress
                {
                    NamedPlace = "Hippodrome de Longchamp",
                    City = "Paris",
                    ZipCode = 75016,
                    StreetName = "Route des Tribunes",
                    StreetNumber = 2
                },
                iggyPop,
                ticketFestival,
                null
            );

            _eventService.CreateEvent(
                TypeEvent.CONCERT,
                "Return of Bowie",
                DateTime.Parse("2025-06-28 14:00"),
                DateTime.Parse("2025-06-30 23:59"),
                new Adress
                {
                    NamedPlace = "Le Splendid",
                    City = "Lille",
                    ZipCode = 59000,
                    StreetName = "Place du Mont de terre",
                    StreetNumber = 1
                },
                bowie,
                ticketConcertVIP,
                null
            );

            _eventService.CreateEvent(
                TypeEvent.CONCERT,
                "Indochine - Central Tour",
                DateTime.Parse("2025-05-10 20:00"),
                DateTime.Parse("2025-05-10 23:30"),
                zenithAddress,
                indochine,
                ticketConcertStandard,
                null
            );




        }
    }
}
