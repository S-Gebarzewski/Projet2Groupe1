namespace Projet2Groupe1.Models
{
    public interface IUserService : IDisposable
    {
        public int CreateUser(string FirstName, string LastName, int? Phone, string Mail, string Password, bool Newsletter, UserRole Role = UserRole.DEFAULT);
        public User searchUser(int id);
        public User ObtainUser(int id);
        public User ObtainUser(string idStr);
        public User Authentication(string Mail, string Password);
    }
}
