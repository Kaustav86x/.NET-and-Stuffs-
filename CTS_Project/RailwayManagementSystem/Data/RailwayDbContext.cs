using Microsoft.EntityFrameworkCore;
using RailwayManagementSystem.Models;

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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer(
                @"Server=(localdb)\MSSQLLocalDB;Database=RailwaySystem;"));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // class to Reservation (1:N)
            modelBuilder.Entity<Class>()
                .HasMany(a => a.Reservations)
                .WithOne(b => b.Class)
                .HasForeignKey(c => c.Class_id).IsRequired();
            // Payment to Reservation (1:N)
            modelBuilder.Entity<Payment>()
                .HasMany(a => a.Reservations)
                .WithOne(b => b.Payment)
                .HasForeignKey(c => c.Payment_id).IsRequired();
            // Train_detail to Reservation (1:N)
            modelBuilder.Entity<Train_detail>()
                .HasMany(a => a.Reservations)
                .WithOne(b => b.Train_detail)
                .HasForeignKey(c => c.Train_id).IsRequired();
            // Ticket_detail to Reservation (1:N)
            modelBuilder.Entity<Ticket_detail>()
                .HasMany(a => a.Reservations)
                .WithOne(b => b.Ticket_Detail)
                .HasForeignKey(c => c.Ticket_id).IsRequired();
            // User to Reservation (1:N)
            modelBuilder.Entity<User>()
                .HasMany(a => a.Reservations)
                .WithOne(b => b.User)
                .HasForeignKey(c => c.User_id).IsRequired();
            // Role to User (1:1)
            modelBuilder.Entity<Role>()
                .HasOne(a => a.User)
                .WithOne(b => b.Role)
                .HasForeignKey<User>(c => c.Role_id).IsRequired();
            // User to Ticket_details(1:N)
            modelBuilder.Entity<User>()
                .HasMany(a => a.Ticket_Details)
                .WithOne(b => b.User)
                .OnDelete(DeleteBehavior.ClientCascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}
