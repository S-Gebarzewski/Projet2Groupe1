using System.ComponentModel;
using Microsoft.EntityFrameworkCore;
using NuGet.Common;

namespace Projet2Groupe1.Models
{
    public class FileService : IDisposable
    {
        protected DataBaseContext _dbContext;

        public FileService()
        {
            _dbContext = new DataBaseContext();
        }

        public User AddUser(User user)
        {
            Console.WriteLine("ajout User BDD");
            this._dbContext.Users.Add(user);
            this._dbContext.SaveChanges();
            return user;

        }

        public List<User> GetUsers()
        {
            return this._dbContext.Users.ToList();
        }

        public User GetUser(int id)
        {
            return this._dbContext.Users.Find(id);
        }



        // à voir si ok, dans code vincent : appelle initialize sur bdd
        public void initBdd()
        {
            using(IDal dal = new Dal())
            {
                dal.InitializeDb();
            }
        }


        public Event AddEvent(Event eventItem)
        {
            Console.WriteLine("ajout User BDD");
            this._dbContext.Events.Add(eventItem);
            this._dbContext.SaveChanges();
            return eventItem;

        }

        public Event GetEvent(int id)
        {
            return this._dbContext.Events.Find(id);
        }

        public List<Event> GetEvents()
        {
            return this._dbContext.Events.ToList();
        }





        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}
