namespace Projet2Groupe1.Models
{
    // cadre de mon user
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Phone { get; set; }
        public string Mail { get; set; }
        public string Password { get; set; }
        public bool Newsletter { get; set; }
        public UserRole Role { get; set; } // appel a mon enum 
        


    }
}
