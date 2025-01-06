using Microsoft.EntityFrameworkCore;

namespace Projet2Groupe1.Models
{
    public class DataBaseContext : DbContext 
    {
        // CRUD, creation des tables, connexion BDD
        public DbSet<User> Users { get; set; } // creation d'une table 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) // connexion BDD
        {
            optionsBuilder.UseMySql("server=localhost;user id=root;password=P@ssw0rd;database=SoundTogether"); // modifer mdp
        }
    }
}
