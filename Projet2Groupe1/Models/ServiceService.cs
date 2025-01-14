using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace Projet2Groupe1.Models
{
    public class ServiceService : IServiceService
    {
        private DataBaseContext _dbContext;
        public ServiceService(DataBaseContext _dbContext)
        {
            this._dbContext = _dbContext;
        }


        public string GetDisplayName(Enum value)
        {
            var EnumName = value.GetType().GetField(value.ToString());
            var AttributeDisplay = EnumName.GetCustomAttribute<DisplayAttribute>();
            return AttributeDisplay.Name;
        }

        public int CreateService(string NameService, TypeService TypeService, int QuantityService, string DescriptionService, int PriceService)
        {
            Service Service = new Service()
            {
                NameService = NameService,
                TypeService = TypeService,
                QuantityService = QuantityService,
                DescriptionService = DescriptionService,
                PriceService = PriceService
            };
            Console.WriteLine("dans createService,avant le add, service est " + Service.ToString());
            _dbContext.Services.Add(Service);
            _dbContext.SaveChanges();
            Console.WriteLine("dans createService,avant le add, service est " + Service.ToString());
            return Service.Id;
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }
    }
}
