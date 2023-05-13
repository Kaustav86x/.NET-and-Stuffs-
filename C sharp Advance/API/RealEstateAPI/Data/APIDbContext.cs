using Microsoft.EntityFrameworkCore;
using RealEstateAPI.Models;

namespace RealEstateAPI.Data
{
    public class APIDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        // dbset connecting with the database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=RealEstate;"));
        }
    }
}
