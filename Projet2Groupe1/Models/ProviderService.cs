namespace Projet2Groupe1.Models
{
    public class ProviderService : IProviderService
    {
        private DataBaseContext _dbContext;
        public ProviderService(DataBaseContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public int CreateProvider(string position, string serviceType, Adress adresss, int userId)
        {
            Adress adress = new Adress
            {
                ZipCode = adresss.ZipCode,
                City = adresss.City,
                StreetName = adresss.StreetName,
                StreetNumber = adresss.StreetNumber,
                NamedPlace = adresss.NamedPlace,
                StreetComplement = adresss.StreetComplement
            };
            Provider provider = new Provider
            {
                Position = position,
                ServiceType = serviceType,
                Adress = adress,
                UserId = userId
            };
            _dbContext.Providers.Add(provider);
            _dbContext.SaveChanges();
            return provider.Id;

          
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public Provider GetProvider(int id)
        {
            return _dbContext.Providers.FirstOrDefault(p => p.Id == id);
        }
    }
}
