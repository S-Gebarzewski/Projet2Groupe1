using Microsoft.EntityFrameworkCore;

namespace Projet2Groupe1.Models
{
    public class DataBaseContext : DbContext 
    {
        // CRUD, creation des tables, connexion BDD
        public DbSet<User> Users { get; set; } // creation d'une table 
        public DbSet<Organizer> Organizers { get; set; } 

        public DbSet<Member> Members { get; set; }

        public DbSet<Provider> Providers { get; set; }

        public DbSet<Admin> Admins { get; set; }

        public DbSet<Event> Events { get; set; }

        public DbSet<Billeterie> Billetteries { get; set; }

        public DbSet<UserTicket> UserTickets { get; set; }

        public DbSet<Service> Services { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // connexion BDD
        {
            optionsBuilder.UseMySql("server=localhost;user id="+DotEnv.IdDb+";password="+DotEnv.Password+";database=SoundTogether"); // modifer mdp
        }
    }
}
