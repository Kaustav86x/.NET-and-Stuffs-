using Microsoft.EntityFrameworkCore;
using RentaCar.Models.Domain;

namespace RentaCar.Data
{
    public class CarDbContext : DbContext // an abstraction over the database
    {
        public CarDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Car> Cars { get; set; } // an abstraction over the database table
        public DbSet<User> Users { get; set; }
    }
}
