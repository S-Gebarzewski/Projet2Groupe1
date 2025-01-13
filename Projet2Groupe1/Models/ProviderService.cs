namespace Projet2Groupe1.Models
{
    public class ProviderService : IProviderService
    {
        private DataBaseContext _dbContext;
        public ProviderService(DataBaseContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public int CreateProvider(string function, string serviceType, Adress adress, int userId)
        {
            Adress Adress = new Adress
            {
                ZipCode = adress.ZipCode,
                City = adress.City,
                StreetName = adress.StreetName,
                StreetNumber = adress.StreetNumber,
                NamedPlace = adress.NamedPlace,
                StreetComplement = adress.StreetComplement
            };
            Provider provider = new Provider
            {
                Function = function,
                ServiceType = serviceType,
                Adress = Adress,
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
