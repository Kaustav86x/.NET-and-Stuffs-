using System.ComponentModel.DataAnnotations;

namespace RailwayManagementSystem.Models.DbModels
{
    // one-to-many with Reservation
    // many-to-one with User
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
        /*[Required]
        public int Amount_paid { get; set;}*/
        [Required]
        public string Payment_status { get; set; }
        public string UserId { get; set;}
        public virtual User? User { get; set; }
        // public string ClassId { get; set; }   
        public virtual Class? Class { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
