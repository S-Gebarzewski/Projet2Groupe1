namespace Projet2Groupe1.Models
{
    public class UserService : IUserService
    {
        private DataBaseContext _dbContext = Dal.getDbContext();
       
        public int CreateUser(string FirstName, string LastName, int Phone, string Email, string Password, UserRole Role)
        {
            User user = new User()
            {
                FirstName = FirstName,
                LastName = LastName,
                Phone = Phone,
                Email = Email,
                Password = Password,
                Role = Role
            };

            _dbContext.Users.Add(user); // ma DB, ma table, ma fonction
            _dbContext.SaveChanges(); // save object user in object DB

            return user.Id;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
