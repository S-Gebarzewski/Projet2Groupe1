﻿using Microsoft.EntityFrameworkCore;
namespace Projet2Groupe1.Models
{
    public class OrganizerService : IOrganizerService
    {
        private DataBaseContext _dbContext;
        public OrganizerService(DataBaseContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        public int CreateOrganizer(string Function, string Denomination, string RIB, Adress? Adress, int UserId)
        {
            Organizer organizer = new Organizer()
            {
                Function = Function,
                Denomination = Denomination,
                RIB = RIB,
                Adress = Adress,
                UserId = UserId
            };
            Console.WriteLine("dans createorganizer,avant le add, function organizer vaut  " + Function);
            _dbContext.Organizers.Add(organizer); // ma DB, ma table, ma fonction
            _dbContext.SaveChanges(); // save object user in object DB
            Console.WriteLine("dans createorganizer,apres le add, function organizer vaut  " + Function);
            return organizer.Id;
        }


        public User ObtainOrganizer(int id)
        {
            throw new NotImplementedException();
        }

        public User searchOrganizer(int id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }
    }
}
