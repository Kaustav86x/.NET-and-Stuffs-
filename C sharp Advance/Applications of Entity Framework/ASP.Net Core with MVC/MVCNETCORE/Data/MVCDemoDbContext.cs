using Microsoft.EntityFrameworkCore;
using MVCNETCORE.Models.Domain;

namespace MVCNETCORE.Data
{
    public class MVCDemoDbContext : DbContext
    {
        public MVCDemoDbContext(DbContextOptions options) : base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
