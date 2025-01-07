using Projet2Groupe1.Models;

namespace Projet2Groupe1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); // recuperer le builder de l'appli
            builder.Services.AddControllersWithViews(); // config le type d'app
            var app = builder.Build(); // 

            app.UseStaticFiles(); // use wwwroot
            app.UseRouting(); // use paths
            app.UseAuthentication();    
            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });


            using (IDal Dal = new Dal())
            {
                Dal.DeleteCreateDb();
                Dal.InitializeDb();
            };

            app.Run();
        }
    }
}
