using System.Collections.Generic;

namespace Projet2Groupe1.Models
{
    public interface IAdminService : IDisposable
    {
        public List<User> GetUsersByStatus(statusRegistration StatusRegistration, UserRole Role);
        public int CreateAdmin(LevelAdmin LevelAdmin, int UserId);
        public Admin searchAdmin(int id);
        public Admin GetAdmin(int id);
        public Admin GetAdmin(string idStr);
        public Admin UpdateAdmin(Admin UpdatingAdmin);
      
    }
}
