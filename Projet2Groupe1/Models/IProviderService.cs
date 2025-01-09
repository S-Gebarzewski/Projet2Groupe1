namespace Projet2Groupe1.Models
{
    public interface IProviderService : IDisposable
    {
        public int CreateProvider(string position, string serviceType,Adress adress, int userId);
        public Provider GetProvider(int id);
    }
}
