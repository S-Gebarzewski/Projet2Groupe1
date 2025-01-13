namespace Projet2Groupe1.Models
{
    public interface IUserService : IDisposable
    {

        public int CreateUser(string FirstName, string LastName, string Phone, string Mail, string Password, bool Newsletter, statusRegistration statusRegistration, UserRole Role = UserRole.DEFAULT);
        public User searchUser(int id);
        public User GetUser(int id);
        public User GetUser(string idStr);
        public User Authentication(string Mail, string Password);
        public User UpdateUser(User UpdatingUser);
    }
}
