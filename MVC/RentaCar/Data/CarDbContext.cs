using Microsoft.EntityFrameworkCore;
using RentaCar.Models.Domain;

namespace RentaCar.Data
{
    public class CarDbContext : DbContext 
    {
        public CarDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; } 
        public DbSet<User> Users { get; set; }
    }
}
