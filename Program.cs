using Microsoft.AspNetCore.Builder;

namespace Zadacha1zhd
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var app = builder.Build();

            app.UseHttpsRedirection();

            app.MapGet("/", () => "Hello World!");

            app.Run();
        }
    }
}
