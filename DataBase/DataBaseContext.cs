using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Zadacha1zhd.Models;

namespace Zadacha1zhd.DataBase
{
    public class DataBaseContext : IdentityDbContext<AuthenticationModel>
    {
        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {
        }
    }
}
