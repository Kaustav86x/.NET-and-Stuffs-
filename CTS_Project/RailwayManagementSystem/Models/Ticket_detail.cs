using System.ComponentModel.DataAnnotations;

namespace RailwayManagementSystem.Models
{
    // many-to-one with User
    // one-to-many with Reservation
    public class Ticket_detail
    {
        public int Id { get; set; }
        [Required]
        public string Train_name { get; set; }
        [Required]
        public string Passenger { get; }
        [Required]
        // some trains don't have a class specification
        public string? class_type { get; set; }
        [Required]
        public string Seat_no { get; set;}
        [Required]
        public DateTime Date { get; set;}
        [Required]
        public int Fare { get; set;}
        // foreign key
        public int User_id { get; set; }
        public virtual User? User { get; set; }
    }
}
