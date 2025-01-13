namespace Projet2Groupe1.Models
{
    public interface IUserService : IDisposable
    {

        public int CreateUser(string FirstName, string LastName, string Phone, string Mail, string Password, bool Newsletter,  UserRole Role = UserRole.DEFAULT);

        public User searchUser(int id);
        public User GetUser(int id);
        public User GetUser(string idStr);
        public User UpdateUser(User user);
        public User Authentication(string Mail, string Password);

    }
}
