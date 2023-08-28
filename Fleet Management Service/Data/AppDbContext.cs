using Microsoft.EntityFrameworkCore;
using Fleet_Management_Service.Models;

namespace Fleet_Management_Service.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Vessel> Vessels { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Fleet> Fleets { get; set; }
    }
}
