using System.ComponentModel.DataAnnotations;

namespace RailwayManagementSystem.Models
{
    // one-to-many with Reservation
    // many-to-many with class
    public class Class
    {
        public Class() 
        { 
            Reservations = new HashSet<Reservation>(); 
        }
        [Required]
        public int Id { get; set; }
        [Required] 
        public string Class_type { get; set; }
        [Required]
        public int Fare { get; set; }
        // foreign key
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}