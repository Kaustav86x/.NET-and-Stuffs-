using Microsoft.EntityFrameworkCore;
using RailwayManagementSystem.Models.DbModels;

namespace RailwayManagementSystem.Data
{
    public class RailwayDbContext : DbContext
    {
       /* public RailwayDbContext() : base("name=RailwayDbContext")
        { }*/

        public DbSet<Class> Classes { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Train_Detail_Class> TrainDetailClass { get; set; }
        public DbSet<Ticket_detail> TicketDetails { get; set; }
        public DbSet<Train_detail> TrainDetails { get; set; }
        public DbSet<User> Users { get; set; }

        //public DbSet<Tick>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=RailwaySystem;"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Train_Detail_Class to Class (1:N)
            modelBuilder.Entity<Train_Detail_Class>()
                .HasMany(a => a.Classes)
                .WithOne(b => b.Train_Detail_Classes)
                .HasForeignKey(c => c.TDCID).IsRequired();
            // Train_Detail_Class to Train_detail (1:N)
            modelBuilder.Entity<Train_Detail_Class>()
                .HasMany(a => a.TrainDetails)
                .WithOne(b => b.Train_Detail_Classes)
                .HasForeignKey(c => c.TDCID).IsRequired();
            // Payment to Reservation (1:1)
            modelBuilder.Entity<Reservation>()
                .HasOne(a => a.Payment)
                .WithOne(b => b.Reservations)
                .HasForeignKey<Payment>(c => c.ReservationId).IsRequired();
            // Train_detail to Reservation (1:N)
            modelBuilder.Entity<Train_detail>()
                .HasMany(a => a.Reservations)
                .WithOne(b => b.Train_detail)
                .HasForeignKey(c => c.TrainId).IsRequired();
            // User to Reservation (1:N)
            modelBuilder.Entity<User>()
                .HasMany(a => a.Reservations)
                .WithOne(b => b.User)
                //.OnDelete(DeleteBehavior.ClientSetNull);
                .HasForeignKey(c => c.UserId).IsRequired();
            // Role to User (1:N)
            modelBuilder.Entity<Role>()
                .HasMany(a => a.Users)
                .WithOne(b => b.Role)
                .HasForeignKey(c => c.RoleId).IsRequired();
            // ticket_detail to payment(1:1)
            modelBuilder.Entity<Payment>()
                .HasOne(a => a.Ticket_Details)
                .WithOne(b => b.Payment)
                .HasForeignKey<Ticket_detail>(c => c.PaymentId).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
