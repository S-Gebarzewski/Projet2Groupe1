namespace Projet2Groupe1.Models
{
    public interface IProviderService : IDisposable
    {
        public int CreateProvider(string function, string serviceType,Adress adress, int userId);
        public Provider GetProvider(int id);
    }
}
