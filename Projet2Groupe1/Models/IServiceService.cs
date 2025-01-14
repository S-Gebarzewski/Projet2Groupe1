namespace Projet2Groupe1.Models
{
    public interface IServiceService : IDisposable
    {
        public string GetDisplayName(Enum value);
        public int CreateService(string NameService, TypeService TypeService, int QuantityService, string DescriptionService, int PriceService);
    }
}
