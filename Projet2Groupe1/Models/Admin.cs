using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Projet2Groupe1.Models
{
    public class Admin
    {
        public int Id { get; set; }
        public LevelAdmin LevelAdmin { get; set; }
        public int UserId { get; set; }

        public override String ToString()
        {
            return $"Creation d'un Admin : id {Id} - LevelAdmin : {LevelAdmin}";
        }
    }    
}
