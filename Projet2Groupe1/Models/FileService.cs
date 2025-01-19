using System.ComponentModel;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
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


        public void SaveEventPicture(int eventId, byte[] imageData)
        {
            try
            {
                Console.WriteLine($"Début SaveEventPicture - EventId: {eventId}, imageData est null: {imageData == null}");
                //trouver l'event avec l'id fourni dans le formulaire
                Event eventItem = this._dbContext.Events.Find(eventId);
                if (eventItem != null)
                {
                    Console.WriteLine($"Event trouvé, Type: {eventItem.TypeEvent}");

                    if (imageData == null)
                    {
                        eventItem.PhotoData = null;
                        this._dbContext.SaveChanges();
                        Console.WriteLine("Image par défaut");
                    }
                      
                     
                     else  if (imageData != null)
                    {
                        eventItem.PhotoData = imageData;
                        this._dbContext.SaveChanges();
                        Console.WriteLine("Image sauvegardée");

                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erreur dans SaveEventPicture: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
                throw;

            }
            
        }

        public string GetDefaultImagePath(TypeEvent type)
        {
            if (type == TypeEvent.CONCERT)
            {
                return "images/concert.png";
            }

            else if (type == TypeEvent.FESTIVAL)
            {
                return "images/festival.png";
            }
            else
            {

                return "images/dedicace.png";
            }  
           
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
