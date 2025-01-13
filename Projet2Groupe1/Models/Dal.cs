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
            _userService.CreateUser("Admin", "ISIKA", "0450452356", "admin@gmail.com", "1234", true, statusRegistration.ACCEPTED, UserRole.ADMIN);
            //// _adminService.CreateAdmin(LevelAdmin.BASE, 1);
            _userService.CreateUser("Organizer", "OG", "0612092937", "og@gmail.com", "1234", true, statusRegistration.PENDING, UserRole.ORGANIZER);
            //_userService.CreateUser("Organizer", "ISIKA", "0450452356", "organizer@gmail.com", "1234", true, UserRole.ORGANIZER);
            //// _organizerService.CreateOrganizer("Directeur commercial", "SA", "XXX99 XXX45 XXXXX678901 XX", null, 2);

            //_userService.CreateUser("Provider", "ISIKA", "0450452356", "provider@gmail.com", "1234", true, UserRole.PROVIDER);
            //// _providerService.CreateProvider("Directeur", "Foodtruck", null, 3);

            //_userService.CreateUser("Member", "ISIKA", "0450452356", "member@gmail.com", "1234", true, UserRole.MEMBER);
            //// _memberService.CreateMember(24, "Caen", "14000", false, false, 4);

            //_userService.CreateUser("Premium", "ISIKA", "0450452356", "premium@gmail.com", "1234", true, UserRole.PREMIUM);
            //// _memberService.CreateMember(34, "Paris", "75000", true, true, 5);
        }
    }
}
