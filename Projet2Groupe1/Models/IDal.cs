namespace Projet2Groupe1.Models
{
    public interface IDal : IDisposable
    {
        public void DeleteCreateDb();
        public void InitializeDb();

    }
}
