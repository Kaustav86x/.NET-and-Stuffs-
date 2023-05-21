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
            base.OnModelCreating(modelBuilder);
        }
    }
}
