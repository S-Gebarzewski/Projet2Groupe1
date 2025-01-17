using Microsoft.EntityFrameworkCore;

namespace Projet2Groupe1.Models
{
    public class Dal : IDal
    {
        private DataBaseContext _dbContext;
        private UserService _userService;
        private AdminService _adminService;
        private OrganizerService _organizerService;
        private ProviderService _providerService;
        private MemberService _memberService;     
        private EventService _eventService;
        private TicketService _ticketService;

        public Dal () 
        {
            _dbContext = new DataBaseContext();
            _userService = new UserService(_dbContext);

            _eventService = new EventService(_dbContext);

            _organizerService = new OrganizerService(_dbContext);
            _eventService = new EventService(_dbContext);
            _ticketService = new TicketService(_dbContext);
            _memberService = new MemberService(_dbContext);

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
            _userService.CreateUser("Admin", "ISIKA", "0450452356", "admin@gmail.com", "1234", true, statusRegistration.ACCEPTED, UserRole.ADMIN);

            _userService.CreateUser("Organizer", "OG", "0612092937", "og@gmail.com", "1234", true, statusRegistration.PENDING, UserRole.ORGANIZER);


            _userService.CreateUser("Admin", "ISIKA", "0450452356", "admin@gmail.com", "1234", true, statusRegistration.ACCEPTED, UserRole.ADMIN);
            _userService.CreateUser("Organizer", "ISIKA", "0450452356", "organizer@gmail.com", "1234", true, statusRegistration.ACCEPTED, UserRole.ORGANIZER);
            _userService.CreateUser("Provider", "ISIKA", "0450452356", "provider@gmail.com", "1234", true, statusRegistration.ACCEPTED, UserRole.PROVIDER);
            _userService.CreateUser("Member", "ISIKA", "0450452356", "member@gmail.com", "1234", true, statusRegistration.ACCEPTED, UserRole.MEMBER);
            _memberService.CreateMember(20, "Lille", "59000", false, false, 6);
            _userService.CreateUser("Premium", "ISIKA", "0450452356", "premium@gmail.com", "1234", true, statusRegistration.ACCEPTED, UserRole.PREMIUM);

            
            

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
            var ticketConcertStandard = new Billeterie
            {
                Category = "Standard",
                NumberTotalTicket = 2000,
                UnitPriceTicket = 45
            };

            var ticketConcertVIP = new Billeterie
            {
                Category = "VIP",
                NumberTotalTicket = 200,
                UnitPriceTicket = 120
            };

            var ticketFestival = new Billeterie
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

                statusRegistration.PENDING,
                TypeService.FOOD,
                2,
                0
 
            );

            _eventService.CreateEvent(
                TypeEvent.CONCERT,
                "Stromae - Multitude Tour",
                DateTime.Parse("2025-04-20 20:00"),
                DateTime.Parse("2025-04-20 23:00"),
                olympiaAddress,
                stromae,
                ticketConcertVIP,
                statusRegistration.PENDING,
                TypeService.FOOD,
                2,
                0
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
                statusRegistration.PENDING,
                TypeService.FOOD,
                2,
                0
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
                statusRegistration.PENDING,
                TypeService.FOOD,
                2,
                0
            );

            _eventService.CreateEvent(
                TypeEvent.CONCERT,
                "Indochine - Central Tour",
                DateTime.Parse("2025-05-10 20:00"),
                DateTime.Parse("2025-05-10 23:30"),
                zenithAddress,
                indochine,
                ticketConcertStandard,
                statusRegistration.PENDING,
                TypeService.FOOD,
                2,
                0
            );


            _organizerService.CreateOrganizer("PDG", "Les Jeux de Wacim", "XXXAAXXXAAXXXAAXXXAATRTTUHX", null, 5);

            Artist artist = new Artist
            {
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
            Billeterie ticket = new Billeterie 
              {
                    Category = "VIP",
                    NumberTotalTicket = 100,
                    UnitPriceTicket = 150
                };
            Service service = new Service
            {
                
                NameService = "Los Monteros",
                TypeService = TypeService.ASSEMBLY,
                QuantityService = 2,
                DescriptionService = "Service de montage/demontage de scene.",
                PriceService = 100,
                UserId = 5
            };


            //(TypeEvent TypeEvent, string NameEvent, DateTime StartEvent, DateTime EndEvent, Adress? AdressData, Artist? Artist, Billeterie? billeterie, statusRegistration StatusRegistration, TypeService TypeService, int QuantityService, int userId)
            _eventService.CreateEvent(TypeEvent.CONCERT, "Concert Linkin Park", DateTime.Now, DateTime.Now.AddHours(3), adress, artist, ticket, statusRegistration.ACCEPTED, TypeService.SECURITY, 1,0 );
            _eventService.CreateEvent(TypeEvent.CONCERT, "Concert Metallica", DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(3), adress, artist, ticket, statusRegistration.PENDING, TypeService.FOOD, 1,0);
            _eventService.CreateEvent(TypeEvent.CONCERT, "Concert Khaled", DateTime.Now.AddDays(2), DateTime.Now.AddDays(2).AddHours(3), adress, artist, ticket, statusRegistration.PENDING, TypeService.FOOD, 1,0 );
            _eventService.CreateEvent(TypeEvent.CONCERT, "Concert Snake", DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddHours(3), adress, artist, ticket, statusRegistration.PENDING, TypeService.SECURITY,1,0);
            _ticketService.CreateTicket(1, 1, 1, 1);
        }
    }
}
