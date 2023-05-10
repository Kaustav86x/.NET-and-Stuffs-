using Microsoft.EntityFrameworkCore;
using MVCCRUDAPP.Models.Domain;

namespace MVCCRUDAPP.Data
{
    public class MVCDbContext : DbContext // dbcontext is the bridge between database and entity framework
    {
        public MVCDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
 