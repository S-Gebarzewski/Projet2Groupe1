﻿using System.Text;
using System.Security.Cryptography;
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

        public int CreateUser(string FirstName, string LastName, string Phone, string Mail, string Password, bool Newsletter, statusRegistration statusRegistration = statusRegistration.ACCEPTED, UserRole Role = UserRole.DEFAULT)
        {
            Console.WriteLine("dans Create user Password est : " + Password + " et password encode vaut : " + EncodeMD5(Password));
            User user = new User()
            {
                FirstName = FirstName,
                LastName = LastName,
                Phone = Phone,
                Mail = Mail,
                Password = EncodeMD5(Password),
                Newsletter = Newsletter,
                StatusRegistration = statusRegistration,
                Role = Role                
            };
            Console.WriteLine("APRES CREATION DU USER dans Create user Password est : " + Password + " et password encode vaut : " + EncodeMD5(Password));
            _dbContext.Users.Add(user); // ma DB, ma table, ma fonction
            _dbContext.SaveChanges(); // save object user in object DB

            return user.Id;
        }

        public User GetUser(int id)
        {
           return _dbContext.Users.Find(id);
        }

        public User GetUser(string idStr)
        {
            int id;
            if (int.TryParse(idStr, out id))
            {
                return this.GetUser(id);
            }
            return null;
        }
        public User UpdateUser(User user)
        {
            User ExistingUser = _dbContext.Users.Find(user.Id);
            if (ExistingUser != null)
            {
                ExistingUser.Id = user.Id;
                ExistingUser.FirstName = user.FirstName;
                ExistingUser.LastName = user.LastName;  
                ExistingUser.Phone = user.Phone;
                ExistingUser.Mail = user.Mail;  
                ExistingUser.Password = EncodeMD5(user.Password);  
                ExistingUser.Newsletter = user.Newsletter;
                ExistingUser.Role = user.Role;
                ExistingUser.StatusRegistration = user.StatusRegistration;
                ExistingUser.PhotoData = user.PhotoData;

                _dbContext.Users.Update(ExistingUser);
                _dbContext.SaveChanges();
            }
            return ExistingUser;

        }
     
        public User UpdateUserStatus(User UpdatingUser)
        {
            User ExistingUser = GetUser(UpdatingUser.Id);

            ExistingUser.StatusRegistration = UpdatingUser.StatusRegistration;

            _dbContext.Users.Update(ExistingUser);
            _dbContext.SaveChanges();

            return ExistingUser;
        }

        public User UpdateUserRole(User UpdatingUser)
        {
            User ExistingUser = GetUser(UpdatingUser.Id);

            ExistingUser.Role = UpdatingUser.Role;

            _dbContext.Users.Update(ExistingUser);
            _dbContext.SaveChanges();

            return ExistingUser;
        }

        public User searchUser(int id)
        {
            return _dbContext.Users.FirstOrDefault(s => s.Id == id);
        }
        private string EncodeMD5(string Password)
        {
            string SaltPassword= "Raven" + Password + "Natacha";
            return BitConverter.ToString(new MD5CryptoServiceProvider().ComputeHash(ASCIIEncoding.Default.GetBytes(SaltPassword)));
        }

        public User Authentication(string Mail, string Password)
        {
            string PWDEncrypted = EncodeMD5(Password);
            User user = this._dbContext.Users.FirstOrDefault(x => (x.Mail == Mail) && (x.Password == PWDEncrypted));
            return user;
        }

        public void Dispose()
        {
            this._dbContext.Dispose();

        }
    }
}
