using Microsoft.EntityFrameworkCore;
using AspDotNetCoreAPI.Model;

namespace AspDotNetCoreAPI.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<PersonModel> persons { get; set; }

    }
}
