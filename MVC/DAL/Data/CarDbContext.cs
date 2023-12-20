using DAL.Model;
using Microsoft.EntityFrameworkCore;
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
        public DbSet<Car> Cars { get; set; }
    }
}
