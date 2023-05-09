using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ExistingCodeFirstDemo
{
    public partial class CodeFirstContext : DbContext
    {
        public CodeFirstContext()
            : base("name=CodeFirstContext")
        {
        }

        public virtual DbSet<Emp> Emps { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Emp>()
                .Property(e => e.fname)
                .IsUnicode(false);

            modelBuilder.Entity<Emp>()
                .Property(e => e.lname)
                .IsUnicode(false);

            modelBuilder.Entity<Emp>()
                .Property(e => e.jobd)
                .IsUnicode(false);
        }
    }
}
