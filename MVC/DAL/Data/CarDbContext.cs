using DAL.Model;
using Microsoft.EntityFrameworkCore;
/*using Microsoft.EntityFrameworkCore;*/
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Data
{
    public class CarDbContext : System.Data.Entity.DbContext
    {
        public CarDbContext() { }
        public CarDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Car> Cars { get; set; }
    }
}
