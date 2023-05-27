using System.ComponentModel.DataAnnotations;

namespace RailwayManagementSystem.Models
{
    // one-to-many with Reservation
    public class Class
    {
        public Class() 
        { 
            Reservations = new HashSet<Reservation>(); 
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public int Fare { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}