using System.Reflection;
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
        private JamService _jamService;

        public Dal()
        {
            _dbContext = new DataBaseContext();
            _userService = new UserService(_dbContext);

            _eventService = new EventService(_dbContext);

            _organizerService = new OrganizerService(_dbContext);
            _eventService = new EventService(_dbContext);
            _ticketService = new TicketService(_dbContext);
            _memberService = new MemberService(_dbContext);
            _jamService  = new JamService(_dbContext);

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
                NickNameArtist = "SSSSSSrr"
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

                statusRegistration.ACCEPTED,
                TypeService.FOOD,
                2,
                0

            );

            _eventService.CreateEvent(
                TypeEvent.CONCERT,
                "sdfgho hjgf",
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
                statusRegistration.ACCEPTED,
                TypeService.FOOD,
                2,
                0
            );

        /*    _eventService.CreateEvent(
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
            );*/

            _eventService.CreateEvent(
                TypeEvent.CONCERT,
                "Indochine - Central Tour",
                DateTime.Parse("2025-05-10 20:00"),
                DateTime.Parse("2025-05-10 23:30"),
                zenithAddress,
                indochine,
                ticketConcertStandard,
                statusRegistration.ACCEPTED,
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

            Adress adress1 = new Adress
            {
                ZipCode = 75018,
                City = "Paris",
                StreetNumber = 12,
                StreetName = "Rue des Artistes",
                NamedPlace = "Louvre Museum",
                StreetComplement = "Near the pyramid"
            };

            Adress adress2 = new Adress
            {
                ZipCode = 74000,
                City = "Annecy",
                StreetNumber = 45,
                StreetName = "Chemin du lac bleu",
                NamedPlace = "Louvre Museum",
                StreetComplement = "Near the pyramid"
            };
            Adress adress3 = new Adress
            {
                ZipCode =69001,
                City = "Lyon",
                StreetNumber = 7,
                StreetName = "Avenue des champs",
                NamedPlace = "Louvre Museum",
                StreetComplement = "Near the pyramid"
            };
            Adress adress4 = new Adress
            {
                ZipCode = 69001,
                City = "Lyon",
                StreetNumber = 7,
                StreetName = "Avenue des champs",
                NamedPlace = "Louvre Museum",
                StreetComplement = "Near the pyramid"
            };

            _jamService.CreateJamSession("Jam session : Jazz sous les étoiles", DateTime.Parse("2025-01-20 19:00"), DateTime.Parse("2025-01-20 23:00"), "Parc Montmarte", 20, "Saxophone",adress1, File.ReadAllBytes("wwwroot/images/defaut-sessionJam.jpg"), 1);
            _jamService.CreateJamSession("Jam session : Blues au bord du lac", DateTime.Parse("2025-02-04 20:00"), DateTime.Parse("2025-02-04 22:00"), "Chemain dulac bleu", 25, "Guitare électrique", adress2, File.ReadAllBytes("wwwroot/images/defaut-sessionJam.jpg"),2 );
            _jamService.CreateJamSession("Jam session : Club de Groove", DateTime.Parse("2025-03-25 18:00"), DateTime.Parse("2025-03-25 20:00"), "Chemain dulac bleu", 35, "Basse", adress3, File.ReadAllBytes("wwwroot/images/defaut-sessionJam.jpg"), 3);
            _jamService.CreateJamSession("Jam session : Café Bohème", DateTime.Parse("2025-05-22 19:00"), DateTime.Parse("2025-05-22 22:00"), "Rue des Poètes", 15, "Guitare acoustique", adress4, File.ReadAllBytes("wwwroot/images/defaut-sessionJam.jpg"), 4);

            //(TypeEvent TypeEvent, string NameEvent, DateTime StartEvent, DateTime EndEvent, Adress? AdressData, Artist? Artist, Billeterie? billeterie, statusRegistration StatusRegistration, TypeService TypeService, int QuantityService, int userId)
            _eventService.CreateEvent(TypeEvent.CONCERT, "Concert Linkin Park", DateTime.Now, DateTime.Now.AddHours(3), adress, artist, ticket, statusRegistration.ACCEPTED, TypeService.SECURITY, 1, 0);
            _eventService.CreateEvent(TypeEvent.CONCERT, "Concert Metallica", DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(3), adress, artist, ticket, statusRegistration.PENDING, TypeService.FOOD, 1, 0);
     /*       _eventService.CreateEvent(TypeEvent.CONCERT, "Concert Khaled", DateTime.Now.AddDays(2), DateTime.Now.AddDays(2).AddHours(3), adress, artist, ticket, statusRegistration.PENDING, TypeService.FOOD, 1, 0);
            _eventService.CreateEvent(TypeEvent.CONCERT, "Concert Snake", DateTime.Now.AddDays(3), DateTime.Now.AddDays(3).AddHours(3), adress, artist, ticket, statusRegistration.PENDING, TypeService.SECURITY, 1, 0);
            _ticketService.CreateTicket(1, 1, 1, 1);*/


            //Ajout de contenu pour présentation ============================================================================================================================================================================================================================
            //===============================================================================================================================================================================================================================================================
            // Création des événements


            var events = new[] {
    new {
        Address = new Adress
        {
            StreetNumber = 8,
            StreetName = "Boulevard de Bercy",
            City = "Paris",
            ZipCode = 75012,
            NamedPlace = "Accor Arena",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Camille",
            LastNameArtist = "Duval",
            NickNameArtist = "LunaSky"
        },
        Ticket = new Billeterie
        {
            Category = "Standard",
            NumberTotalTicket = 5000,
            UnitPriceTicket = 50
        },
        NameEvent = "LunaSky - Starry Night Tour",
        StartDate = DateTime.Parse("2025-04-10 20:00"),
        EndDate = DateTime.Parse("2025-04-10 23:00"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 3
    },
    new {
        Address = new Adress
        {
            StreetNumber = 20,
            StreetName = "Place Charles et Christophe Mérieux",
            City = "Lyon",
            ZipCode = 69007,
            NamedPlace = "Halle Tony Garnier",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Éric",
            LastNameArtist = "Montel",
            NickNameArtist = "Éclipse"
        },
        Ticket = new Billeterie
        {
            Category = "VIP",
            NumberTotalTicket = 1000,
            UnitPriceTicket = 120
        },
        NameEvent = "Éclipse - Moonlight Journey",
        StartDate = DateTime.Parse("2025-04-15 19:30"),
        EndDate = DateTime.Parse("2025-04-15 22:30"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.SECURITY,
        QuantityService = 4
    },
    new {
        Address = new Adress
        {
            StreetNumber = 1,
            StreetName = "Place du Mont de Terre",
            City = "Lille",
            ZipCode = 59000,
            NamedPlace = "Le Splendid",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Clara",
            LastNameArtist = "Valmont",
            NickNameArtist = "Solstice"
        },
        Ticket = new Billeterie
        {
            Category = "Standard",
            NumberTotalTicket = 3000,
            UnitPriceTicket = 60
        },
        NameEvent = "Solstice - Equinoxe Live",
        StartDate = DateTime.Parse("2025-04-20 20:00"),
        EndDate = DateTime.Parse("2025-04-20 22:30"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 2
    },
    new {
        Address = new Adress
        {
            StreetNumber = 48,
            StreetName = "Avenue de Saint-Just",
            City = "Marseille",
            ZipCode = 13004,
            NamedPlace = "Dôme de Marseille",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Romain",
            LastNameArtist = "Leblanc",
            NickNameArtist = "Arkadia"
        },
        Ticket = new Billeterie
        {
            Category = "Standard",
            NumberTotalTicket = 4500,
            UnitPriceTicket = 55
        },
        NameEvent = "Arkadia - Odyssey Sound",
        StartDate = DateTime.Parse("2025-04-25 20:30"),
        EndDate = DateTime.Parse("2025-04-25 23:00"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.SECURITY,
        QuantityService = 3
    },
    new {
        Address = new Adress
        {
            StreetNumber = 211,
            StreetName = "Rue de Colchide",
            City = "Dijon",
            ZipCode = 21000,
            NamedPlace = "Zénith de Dijon",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Julie",
            LastNameArtist = "Métral",
            NickNameArtist = "Polaris"
        },
        Ticket = new Billeterie
        {
            Category = "VIP",
            NumberTotalTicket = 800,
            UnitPriceTicket = 100
        },
        NameEvent = "Polaris - Northern Lights Tour",
        StartDate = DateTime.Parse("2025-04-30 19:00"),
        EndDate = DateTime.Parse("2025-04-30 21:30"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.SECURITY,
        QuantityService = 2
    },
    new {
        Address = new Adress
        {
            StreetNumber = 3,
            StreetName = "Boulevard Ouest",
            City = "Besançon",
            ZipCode = 25000,
            NamedPlace = "Micropolis Besançon",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Victor",
            LastNameArtist = "Dubois",
            NickNameArtist = "Nova"
        },
        Ticket = new Billeterie
        {
            Category = "Standard",
            NumberTotalTicket = 2500,
            UnitPriceTicket = 45
        },
        NameEvent = "Nova - Celestial Voyage",
        StartDate = DateTime.Parse("2025-05-05 20:00"),
        EndDate = DateTime.Parse("2025-05-05 22:30"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 2
    },
    new {
        Address = new Adress
        {
            StreetNumber = 48,
            StreetName = "Avenue Jean Alfonséa",
            City = "Bordeaux",
            ZipCode = 33270,
            NamedPlace = "Arkéa Arena",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Amandine",
            LastNameArtist = "Richard",
            NickNameArtist = "Echo"
        },
        Ticket = new Billeterie
        {
            Category = "Standard",
            NumberTotalTicket = 4000,
            UnitPriceTicket = 50
        },
        NameEvent = "Echo - Sound Waves Tour",
        StartDate = DateTime.Parse("2025-05-10 20:30"),
        EndDate = DateTime.Parse("2025-05-10 23:00"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.SECURITY,
        QuantityService = 3
    },
    new {
        Address = new Adress
        {
            StreetNumber = 11,
            StreetName = "Avenue Raymond Badiou",
            City = "Toulouse",
            ZipCode = 31300,
            NamedPlace = "Zénith Toulouse Métropole",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Théo",
            LastNameArtist = "Martin",
            NickNameArtist = "Skyline"
        },
        Ticket = new Billeterie
        {
            Category = "VIP",
            NumberTotalTicket = 1500,
            UnitPriceTicket = 110
        },
        NameEvent = "Skyline - Infinite Horizon",
        StartDate = DateTime.Parse("2025-05-15 20:00"),
        EndDate = DateTime.Parse("2025-05-15 22:30"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.SECURITY,
        QuantityService = 4
    },
    new {
        Address = new Adress
        {
            StreetNumber = 163,
            StreetName = "Boulevard du Mercantour",
            City = "Nice",
            ZipCode = 06200,
            NamedPlace = "Palais Nikaïa",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Alice",
            LastNameArtist = "Vernet",
            NickNameArtist = "Lumina"
        },
        Ticket = new Billeterie
        {
            Category = "Standard",
            NumberTotalTicket = 3800,
            UnitPriceTicket = 55
        },
        NameEvent = "Lumina - Radiant Glow Tour",
        StartDate = DateTime.Parse("2025-05-20 19:30"),
        EndDate = DateTime.Parse("2025-05-20 22:00"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 2
    },
    new {
        Address = new Adress
        {
            StreetNumber = 1,
            StreetName = "Boulevard du Zénith",
            City = "Nantes",
            ZipCode = 44800,
            NamedPlace = "Zénith de Nantes Métropole",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Mathieu",
            LastNameArtist = "Durant",
            NickNameArtist = "Horizon"
        },
        Ticket = new Billeterie
        {
            Category = "VIP",
            NumberTotalTicket = 1200,
            UnitPriceTicket = 125
        },
        NameEvent = "Horizon - Beyond the Line",
        StartDate = DateTime.Parse("2025-05-25 20:00"),
        EndDate = DateTime.Parse("2025-05-25 23:00"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.SECURITY,
        QuantityService = 3
    },
    new {
        Address = new Adress
        {
            StreetNumber = 2,
            StreetName = "Route de la Foire",
            City = "Montpellier",
            ZipCode = 34470,
            NamedPlace = "Sud de France Arena",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Lucie",
            LastNameArtist = "Petit",
            NickNameArtist = "Aether"
        },
        Ticket = new Billeterie
        {
            Category = "Standard",
            NumberTotalTicket = 4200,
            UnitPriceTicket = 60
        },
        NameEvent = "Aether - Ethereal Sounds",
        StartDate = DateTime.Parse("2025-05-30 20:30"),
        EndDate = DateTime.Parse("2025-05-30 23:00"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 3
    },
    new {
        Address = new Adress
        {
            StreetNumber = 1,
            StreetName = "Allée du Zénith",
            City = "Strasbourg",
            ZipCode = 67201,
            NamedPlace = "Zénith Europe",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Nicolas",
            LastNameArtist = "Rey",
            NickNameArtist = "Atlas"
        },
        Ticket = new Billeterie
        {
            Category = "VIP",
            NumberTotalTicket = 900,
            UnitPriceTicket = 130
        },
        NameEvent = "Atlas - World Bearing Tour",
        StartDate = DateTime.Parse("2025-06-05 19:00"),
        EndDate = DateTime.Parse("2025-06-05 21:30"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.SECURITY,
        QuantityService = 4
    },
    new {
        Address = new Adress
        {
            StreetNumber = 5,
            StreetName = "Esplanade Charles de Gaulle",
            City = "Rennes",
            ZipCode = 35000,
            NamedPlace = "Le Liberté",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Claire",
            LastNameArtist = "Renard",
            NickNameArtist = "Novaella"
        },
        Ticket = new Billeterie
        {
            Category = "Standard",
            NumberTotalTicket = 3000,
            UnitPriceTicket = 50
        },
        NameEvent = "Novaella - Starlight Symphony",
        StartDate = DateTime.Parse("2025-06-10 20:00"),
        EndDate = DateTime.Parse("2025-06-10 22:30"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 2
    }
};

            foreach (var ev in events)
            {
                _eventService.CreateEvent(
                    TypeEvent.CONCERT,
                    ev.NameEvent,
                    ev.StartDate,
                    ev.EndDate,
                    ev.Address,
                    ev.Artist,
                    ev.Ticket,
                    ev.StatusRegistration,
                    ev.TypeService,
                    ev.QuantityService,
                    0 // User ID par défaut ou autre selon besoin
                );
            }

            // Création des festivals

            var festivals = new[] {
    new {
        Address = new Adress
        {
            StreetNumber = 12,
            StreetName = "Route de Longchamp",
            City = "Paris",
            ZipCode = 75016,
            NamedPlace = "Hippodrome de Longchamp",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Sarah",
            LastNameArtist = "Morel",
            NickNameArtist = "Starfall"
        },
        Ticket = new Billeterie
        {
            Category = "Festival Pass",
            NumberTotalTicket = 8000,
            UnitPriceTicket = 150
        },
        NameEvent = "Starfall Festival 2025",
        StartDate = DateTime.Parse("2025-07-01 14:00"),
        EndDate = DateTime.Parse("2025-07-03 23:59"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 5
    },
    new {
        Address = new Adress
        {
            StreetNumber = 10,
            StreetName = "Parc de Gerland",
            City = "Lyon",
            ZipCode = 69007,
            NamedPlace = "Parc de Gerland",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Louis",
            LastNameArtist = "Verdier",
            NickNameArtist = "GreenWave"
        },
        Ticket = new Billeterie
        {
            Category = "Festival Pass",
            NumberTotalTicket = 6000,
            UnitPriceTicket = 140
        },
        NameEvent = "GreenWave Fest 2025",
        StartDate = DateTime.Parse("2025-07-10 15:00"),
        EndDate = DateTime.Parse("2025-07-12 23:59"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.SECURITY,
        QuantityService = 4
    },
    new {
        Address = new Adress
        {
            StreetNumber = 5,
            StreetName = "Promenade des Anglais",
            City = "Nice",
            ZipCode = 06200,
            NamedPlace = "Théâtre de Verdure",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Amélie",
            LastNameArtist = "Durand",
            NickNameArtist = "Sunbeam"
        },
        Ticket = new Billeterie
        {
            Category = "Festival Pass",
            NumberTotalTicket = 7000,
            UnitPriceTicket = 160
        },
        NameEvent = "Sunbeam Music Fest",
        StartDate = DateTime.Parse("2025-07-20 16:00"),
        EndDate = DateTime.Parse("2025-07-22 23:59"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 6
    },
    new {
        Address = new Adress
        {
            StreetNumber = 18,
            StreetName = "Cours Victor Hugo",
            City = "Bordeaux",
            ZipCode = 33000,
            NamedPlace = "Parc Bordelais",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Julien",
            LastNameArtist = "Roche",
            NickNameArtist = "WaveRider"
        },
        Ticket = new Billeterie
        {
            Category = "Festival Pass",
            NumberTotalTicket = 8500,
            UnitPriceTicket = 180
        },
        NameEvent = "WaveRider Festival",
        StartDate = DateTime.Parse("2025-07-25 14:00"),
        EndDate = DateTime.Parse("2025-07-27 23:59"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.SECURITY,
        QuantityService = 5
    },
    new {
        Address = new Adress
        {
            StreetNumber = 22,
            StreetName = "Avenue des Champs-Élysées",
            City = "Paris",
            ZipCode = 75008,
            NamedPlace = "Grand Palais",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Claire",
            LastNameArtist = "Martin",
            NickNameArtist = "EchoHeart"
        },
        Ticket = new Billeterie
        {
            Category = "Festival Pass",
            NumberTotalTicket = 9000,
            UnitPriceTicket = 200
        },
        NameEvent = "EchoHeart Live",
        StartDate = DateTime.Parse("2025-08-01 12:00"),
        EndDate = DateTime.Parse("2025-08-03 23:59"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 7
    },
    new {
        Address = new Adress
        {
            StreetNumber = 3,
            StreetName = "Place de la Comédie",
            City = "Montpellier",
            ZipCode = 34000,
            NamedPlace = "Esplanade Charles-de-Gaulle",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Vincent",
            LastNameArtist = "Blanc",
            NickNameArtist = "SilverChord"
        },
        Ticket = new Billeterie
        {
            Category = "Festival Pass",
            NumberTotalTicket = 7500,
            UnitPriceTicket = 170
        },
        NameEvent = "SilverChord Festival",
        StartDate = DateTime.Parse("2025-08-10 15:00"),
        EndDate = DateTime.Parse("2025-08-12 23:59"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 4
    },

    //==
    // Création de 5 nouveaux festivals

    new {
        Address = new Adress
        {
            StreetNumber = 7,
            StreetName = "Avenue Jean Médecin",
            City = "Nice",
            ZipCode = 06000,
            NamedPlace = "Jardin Albert 1er",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Nicolas",
            LastNameArtist = "Dupont",
            NickNameArtist = "FireBeat"
        },
        Ticket = new Billeterie
        {
            Category = "Festival Pass",
            NumberTotalTicket = 6000,
            UnitPriceTicket = 140
        },
        NameEvent = "FireBeat Summer Fest",
        StartDate = DateTime.Parse("2025-08-20 16:00"),
        EndDate = DateTime.Parse("2025-08-22 23:59"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 6
    },
    new {
        Address = new Adress
        {
            StreetNumber = 11,
            StreetName = "Place Stanislas",
            City = "Nancy",
            ZipCode = 54000,
            NamedPlace = "Parc de la Pépinière",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Emma",
            LastNameArtist = "Laurent",
            NickNameArtist = "SkyTone"
        },
        Ticket = new Billeterie
        {
            Category = "Festival Pass",
            NumberTotalTicket = 7000,
            UnitPriceTicket = 150
        },
        NameEvent = "SkyTone Festival",
        StartDate = DateTime.Parse("2025-09-01 14:00"),
        EndDate = DateTime.Parse("2025-09-03 23:59"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.SECURITY,
        QuantityService = 5
    },
    new {
        Address = new Adress
        {
            StreetNumber = 9,
            StreetName = "Boulevard des Pyrénées",
            City = "Pau",
            ZipCode = 64000,
            NamedPlace = "Parc Beaumont",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Alexandre",
            LastNameArtist = "Fournier",
            NickNameArtist = "PulseWave"
        },
        Ticket = new Billeterie
        {
            Category = "Festival Pass",
            NumberTotalTicket = 5000,
            UnitPriceTicket = 130
        },
        NameEvent = "PulseWave Festival",
        StartDate = DateTime.Parse("2025-09-10 15:00"),
        EndDate = DateTime.Parse("2025-09-12 23:59"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 4
    },
    new {
        Address = new Adress
        {
            StreetNumber = 2,
            StreetName = "Place de la Liberté",
            City = "Toulon",
            ZipCode = 83000,
            NamedPlace = "Parc des Lices",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Sophie",
            LastNameArtist = "Martel",
            NickNameArtist = "EchoLight"
        },
        Ticket = new Billeterie
        {
            Category = "Festival Pass",
            NumberTotalTicket = 8000,
            UnitPriceTicket = 160
        },
        NameEvent = "EchoLight Vibes",
        StartDate = DateTime.Parse("2025-09-20 14:00"),
        EndDate = DateTime.Parse("2025-09-22 23:59"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.SECURITY,
        QuantityService = 5
    },
    new {
        Address = new Adress
        {
            StreetNumber = 13,
            StreetName = "Avenue de la République",
            City = "Strasbourg",
            ZipCode = 67000,
            NamedPlace = "Parc de l'Orangerie",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Julie",
            LastNameArtist = "Perrault",
            NickNameArtist = "CrystalVoice"
        },
        Ticket = new Billeterie
        {
            Category = "Festival Pass",
            NumberTotalTicket = 7500,
            UnitPriceTicket = 150
        },
        NameEvent = "CrystalVoice Festival",
        StartDate = DateTime.Parse("2025-10-01 14:00"),
        EndDate = DateTime.Parse("2025-10-03 23:59"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 6
    }
};

            foreach (var festival in festivals)
            {
                _eventService.CreateEvent(
                    TypeEvent.FESTIVAL,
                    festival.NameEvent,
                    festival.StartDate,
                    festival.EndDate,
                    festival.Address,
                    festival.Artist,
                    festival.Ticket,
                    festival.StatusRegistration,
                    festival.TypeService,
                    festival.QuantityService,
                    0 // User ID par défaut ou autre selon besoin
                );
            }

            // Création de 13 signing sessions

            var signingsessions = new[] {
    new {
        Address = new Adress
        {
            StreetNumber = 14,
            StreetName = "Boulevard Haussmann",
            City = "Paris",
            ZipCode = 75009,
            NamedPlace = "Galeries Lafayette",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Anna",
            LastNameArtist = "Dubois",
            NickNameArtist = "Aurora"
        },
        Ticket = new Billeterie
        {
            Category = "Session Pass",
            NumberTotalTicket = 300,
            UnitPriceTicket = 30
        },
        NameEvent = "Aurora Séance de dédicace",
        StartDate = DateTime.Parse("2025-08-01 15:00"),
        EndDate = DateTime.Parse("2025-08-01 18:00"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 0
    },
    new {
        Address = new Adress
        {
            StreetNumber = 4,
            StreetName = "Place Bellecour",
            City = "Lyon",
            ZipCode = 69002,
            NamedPlace = "Fnac Lyon Bellecour",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Hugo",
            LastNameArtist = "Charpentier",
            NickNameArtist = "Shadow"
        },
        Ticket = new Billeterie
        {
            Category = "Session Pass",
            NumberTotalTicket = 400,
            UnitPriceTicket = 35
        },
        NameEvent = "Shadow Meet & Greet",
        StartDate = DateTime.Parse("2025-08-05 14:00"),
        EndDate = DateTime.Parse("2025-08-05 17:00"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 0
    },
    new {
        Address = new Adress
        {
            StreetNumber = 5,
            StreetName = "Esplanade Charles de Gaulle",
            City = "Rennes",
            ZipCode = 35000,
            NamedPlace = "Le Liberté",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Claire",
            LastNameArtist = "Renard",
            NickNameArtist = "Novaella"
        },
        Ticket = new Billeterie
        {
            Category = "Session Pass",
            NumberTotalTicket = 250,
            UnitPriceTicket = 25
        },
        NameEvent = "Novaella Autograph Session",
        StartDate = DateTime.Parse("2025-08-10 16:00"),
        EndDate = DateTime.Parse("2025-08-10 18:00"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 0
    },
    new {
        Address = new Adress
        {
            StreetNumber = 22,
            StreetName = "Cours Saleya",
            City = "Nice",
            ZipCode = 06300,
            NamedPlace = "Librairie Molière",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Lucas",
            LastNameArtist = "Martin",
            NickNameArtist = "BrightWords"
        },
        Ticket = new Billeterie
        {
            Category = "Session Pass",
            NumberTotalTicket = 500,
            UnitPriceTicket = 40
        },
        NameEvent = "BrightWords Séance de dédicace",
        StartDate = DateTime.Parse("2025-08-15 14:00"),
        EndDate = DateTime.Parse("2025-08-15 17:00"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 0
    },
    new {
        Address = new Adress
        {
            StreetNumber = 18,
            StreetName = "Rue de la République",
            City = "Strasbourg",
            ZipCode = 67000,
            NamedPlace = "Maison du Livre",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Sophie",
            LastNameArtist = "Petit",
            NickNameArtist = "MoonScribe"
        },
        Ticket = new Billeterie
        {
            Category = "Session Pass",
            NumberTotalTicket = 350,
            UnitPriceTicket = 30
        },
        NameEvent = "MoonScribe Séance de dédicace",
        StartDate = DateTime.Parse("2025-08-20 15:00"),
        EndDate = DateTime.Parse("2025-08-20 18:00"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 0
    },


    new {
        Address = new Adress
        {
            StreetNumber = 10,
            StreetName = "Rue de Rivoli",
            City = "Paris",
            ZipCode = 75001,
            NamedPlace = "Librairie Delacroix",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Mathieu",
            LastNameArtist = "Blanc",
            NickNameArtist = "InkPulse"
        },
        Ticket = new Billeterie
        {
            Category = "Session Pass",
            NumberTotalTicket = 400,
            UnitPriceTicket = 35
        },
        NameEvent = "InkPulse Séance de dédicace",
        StartDate = DateTime.Parse("2025-09-01 15:00"),
        EndDate = DateTime.Parse("2025-09-01 18:00"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 0
    },
    new {
        Address = new Adress
        {
            StreetNumber = 22,
            StreetName = "Boulevard des Italiens",
            City = "Lyon",
            ZipCode = 69002,
            NamedPlace = "Librairie Lumière",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Lucie",
            LastNameArtist = "Moreau",
            NickNameArtist = "StarLine"
        },
        Ticket = new Billeterie
        {
            Category = "Session Pass",
            NumberTotalTicket = 300,
            UnitPriceTicket = 30
        },
        NameEvent = "StarLine Meet & Greet",
        StartDate = DateTime.Parse("2025-09-05 14:00"),
        EndDate = DateTime.Parse("2025-09-05 17:00"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 0
    },
    new {
        Address = new Adress
        {
            StreetNumber = 15,
            StreetName = "Rue de Verdun",
            City = "Marseille",
            ZipCode = 13001,
            NamedPlace = "Librairie Horizon",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Emma",
            LastNameArtist = "Dupuis",
            NickNameArtist = "LunaVerse"
        },
        Ticket = new Billeterie
        {
            Category = "Session Pass",
            NumberTotalTicket = 500,
            UnitPriceTicket = 40
        },
        NameEvent = "LunaVerse Séance de dédicace",
        StartDate = DateTime.Parse("2025-09-10 16:00"),
        EndDate = DateTime.Parse("2025-09-10 18:00"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 0
    },
    new {
        Address = new Adress
        {
            StreetNumber = 8,
            StreetName = "Cours Lafayette",
            City = "Bordeaux",
            ZipCode = 33000,
            NamedPlace = "Librairie Aquitaine",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Victor",
            LastNameArtist = "Renaud",
            NickNameArtist = "EchoWriter"
        },
        Ticket = new Billeterie
        {
            Category = "Session Pass",
            NumberTotalTicket = 450,
            UnitPriceTicket = 37
        },
        NameEvent = "EchoWriter Autograph Session",
        StartDate = DateTime.Parse("2025-09-15 14:00"),
        EndDate = DateTime.Parse("2025-09-15 17:00"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 0
    },
    new {
        Address = new Adress
        {
            StreetNumber = 9,
            StreetName = "Rue Jeanne d'Arc",
            City = "Rouen",
            ZipCode = 76000,
            NamedPlace = "Librairie Normande",
            StreetComplement = null
        },
        Artist = new Artist
        {
            FirstNameArtist = "Julie",
            LastNameArtist = "Fabre",
            NickNameArtist = "StarEcho"
        },
        Ticket = new Billeterie
        {
            Category = "Session Pass",
            NumberTotalTicket = 350,
            UnitPriceTicket = 33
        },
        NameEvent = "StarEcho Séance de dédicace",
        StartDate = DateTime.Parse("2025-09-20 15:00"),
        EndDate = DateTime.Parse("2025-09-20 18:00"),
        StatusRegistration = statusRegistration.ACCEPTED,
        TypeService = TypeService.FOOD,
        QuantityService = 0
    }
};

            foreach (var session in signingsessions)
            {
                _eventService.CreateEvent(
                    TypeEvent.SIGNINGSESSION,
                    session.NameEvent,
                    session.StartDate,
                    session.EndDate,
                    session.Address,
                    session.Artist,
                    session.Ticket,
                    session.StatusRegistration,
                    session.TypeService,
                    session.QuantityService,
                    0 // User ID par défaut ou autre selon besoin
                );
            }
        }

           



        }


        //===============================================================================================================================================================================================================================================================




    }
  

