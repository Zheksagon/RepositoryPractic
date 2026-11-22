using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zadacha1zhd.Models;

namespace Zadacha1zhd.DataBase
{
    public class DataBaseContext : IdentityDbContext<AuthenticationModel>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options) { }
        public DbSet<CategoryModel> Categories { get; set; }
        public DbSet<RentProductModel> Products { get; set; }
        public DbSet<BookingModel> Bookings { get; set; }
        public DbSet<PinCodeModel> PinCodes { get; set; }
    }
}
