using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Zadacha1zhd.DataBase;
using Zadacha1zhd.Models;

namespace Zadacha1zhd
{
    public static class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(new WebApplicationOptions
            {
                Args = args,
                WebRootPath = "staticstyle"
            });

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DataBaseContext>(dbOptions =>
                dbOptions.UseSqlite("Data Source=rental.db"));

            builder.Services.AddIdentity<AuthenticationModel, IdentityRole>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<DataBaseContext>();

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute
            (
                name: "default",
                pattern: "{controller=RentProductCatalog}/{action=ProductCatalog}/{id?}"
            );

            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var context = services.GetRequiredService<DataBaseContext>();
                var userManager = services.GetRequiredService<UserManager<AuthenticationModel>>();
                await DBTest.InitializeAsync(context, userManager);
            }

            app.Run();
        }
    }
}
