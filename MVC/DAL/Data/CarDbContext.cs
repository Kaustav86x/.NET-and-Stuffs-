using DAL.Model;
using Microsoft.EntityFrameworkCore;
/*using System.Data.Entity;*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class CarDbContext : DbContext
    {
        public CarDbContext() { }
        public CarDbContext(DbContextOptions options) : base(options) { }
        /* public CarDbContext(DbContextOptions<CarDbContext> options) { }*/
        public DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure CarId as an identity column
            modelBuilder.Entity<Car>()
                .Property(c => c.CarId)
                .ValueGeneratedOnAdd();
        }
    }
}
