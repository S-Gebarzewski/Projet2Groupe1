using Microsoft.EntityFrameworkCore;

namespace Projet2Groupe1.Models
{
    public class UserService : IUserService
    {
        private DataBaseContext _dbContext;
        public UserService(DataBaseContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
       
        public int CreateUser(string FirstName, string LastName, int Phone, string Email, string Password, UserRole Role = UserRole.DEFAULT)
        {
            User user = new User()
            {
                FirstName = FirstName,
                LastName = LastName,
                Phone = Phone,
                Mail = Email,
                Password = Password,
                Role = Role
            };

            _dbContext.Users.Add(user); // ma DB, ma table, ma fonction
            _dbContext.SaveChanges(); // save object user in object DB

            return user.Id;
        }

     

        public User searchUser(int id)
        {
            return _dbContext.Users.FirstOrDefault(s => s.Id == id);
        }

        public void Dispose()
        {
            this._dbContext.Dispose();

        }
        
    }
}
