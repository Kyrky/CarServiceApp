using CarServiceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarServiceApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<RepairCase> RepairCases { get; set; }

        public DbSet<User> Users { get; set; }
    }
}
