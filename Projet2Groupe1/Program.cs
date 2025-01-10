using Microsoft.AspNetCore.Authentication.Cookies;
using Projet2Groupe1.Models;

namespace Projet2Groupe1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args); // recuperer le builder de l'appli

            builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options =>
            {
                options.LoginPath = "/Login/Connection";//On indique la route relative pour s'authentifier
                options.LoginPath = "/Login/disconnection";

            });

            // config le type d'app
            // Ajout des options pour pouvoir utiliser Json dans le projet
            builder.Services.AddControllersWithViews()
                .AddJsonOptions(o => 
            {
                o.JsonSerializerOptions.PropertyNameCaseInsensitive = true;
                o.JsonSerializerOptions.PropertyNamingPolicy = null;

            }); 
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
