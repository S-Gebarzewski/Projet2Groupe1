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

        public List<Service> GetServicesById(int UserId)
        {
            Console.WriteLine("Je suis dans Get Services by id avec l'id prestataire : " + UserId);
            List<Service> Services = _dbContext.Services.Where(s => s.UserId == UserId).ToList();
            Console.WriteLine("nombre de service : " + Services.Count());
            return Services;
        }

        public string GetDisplayName(Enum value)
        {
            var EnumName = value.GetType().GetField(value.ToString());
            var AttributeDisplay = EnumName.GetCustomAttribute<DisplayAttribute>();
            return AttributeDisplay.Name;
        }

        public int CreateService(string NameService, TypeService TypeService, int QuantityService, string DescriptionService, int PriceService, int UserId)
        {
            Service Service = new Service()
            {
                NameService = NameService,
                TypeService = TypeService,
                QuantityService = QuantityService,
                DescriptionService = DescriptionService,
                PriceService = PriceService,
                UserId = UserId
            };
            _dbContext.Services.Add(Service);
            _dbContext.SaveChanges();
            return Service.Id;
        }

        public void Dispose()
        {
            this._dbContext.Dispose();
        }
    }
}
