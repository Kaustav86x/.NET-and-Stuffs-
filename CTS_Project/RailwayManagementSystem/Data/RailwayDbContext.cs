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
            // Train_detail to Class (N:N)
            modelBuilder.Entity<Train_detail>()
                .HasMany(a => a.Classes)
                .WithMany(b => b.Train_details)
                .UsingEntity(
                "TrainDetailClass",
                l => l.HasOne(typeof(Class)).WithMany().HasForeignKey("ClassId").HasPrincipalKey(nameof(Class.Id)),
                r => r.HasOne(typeof(Train_detail)).WithMany().HasForeignKey("TrainDetailId").HasPrincipalKey(nameof(Train_detail.Id)),
                j => j.HasKey("ClassId", "TrainDetailId"));
            // Payment to Reservation (1:1)
            modelBuilder.Entity<Reservation>()
                .HasOne(a => a.Payment)
                .WithOne(b => b.Reservations)
                .HasForeignKey<Payment>(c => c.Reservation_Id).IsRequired();
            // Train_detail to Reservation (1:N)
            modelBuilder.Entity<Train_detail>()
                .HasMany(a => a.Reservations)
                .WithOne(b => b.Train_detail)
                .HasForeignKey(c => c.TrainId).IsRequired();
            // User to Reservation (1:N)
            modelBuilder.Entity<User>()
                .HasMany(a => a.Reservations)
                .WithOne(b => b.User)
                .OnDelete(DeleteBehavior.ClientSetNull);
            // Role to User (1:N)
            modelBuilder.Entity<Role>()
                .HasMany(a => a.Users)
                .WithOne(b => b.Role)
                .HasForeignKey(c => c.RoleId).IsRequired();
            // ticket_detail to payment(1:1)
            modelBuilder.Entity<Payment>()
                .HasOne(a => a.Ticket_Details)
                .WithOne(b => b.Payment)
                .HasForeignKey<Ticket_detail>(c => c.Payment_Id).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
