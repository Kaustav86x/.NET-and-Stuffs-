using System.ComponentModel.DataAnnotations;

namespace RailwayManagementSystem.Models.DbModels
{
    // one-to-many with Reservation
    public class Payment
    {
        public Payment()
        {
            Reservations = new HashSet<Reservation>();
        }
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string Payment_method { get; set; }
        [Required]
        public int Amount_paid { get; set;}
        [Required]
        public string Payment_status { get; set;}
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
