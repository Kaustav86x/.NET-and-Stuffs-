using System.ComponentModel.DataAnnotations;

namespace RailwayManagementSystem.Models
{
    // one-to-many with Reservation
    public class Class
    {
        public int Id { get; set; }
        [Required]
        public int Fare { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}