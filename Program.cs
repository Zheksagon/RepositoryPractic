using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Zadacha1zhd.DataBase;
using Zadacha1zhd.Models;

namespace Zadacha1zhd
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(new WebApplicationOptions
            {
                Args = args,
                WebRootPath = "staticstyle"
            });

            builder.Services.AddControllersWithViews();

            builder.Services.AddDbContext<DataBaseContext>(dbOptions =>
            dbOptions.UseSqlite("Data Source=rental.db"));

            var app = builder.Build();

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute
            (
                name: "default",
                pattern: "{controller=Authentication}/{action=Authentication}/{id?}"
            );

            app.Run();
        }
    }
}
