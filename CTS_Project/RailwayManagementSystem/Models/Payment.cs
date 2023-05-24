using System.ComponentModel.DataAnnotations;

namespace RailwayManagementSystem.Models
{
    // one-to-many with Reservation
    public class Payment
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Payment_method { get; set; }
        [Required]
        public string Amount_paid { get; set;}
        [Required]
        public string Payment_status { get; set;}
        public ICollection<Reservation> Reservations { get; set; }
    }
}
