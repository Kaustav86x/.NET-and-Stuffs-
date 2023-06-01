using System.ComponentModel.DataAnnotations;

namespace RailwayManagementSystem.Models.DbModels
{
    // many-to-one with User
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
        public string User_id { get; set; }
        public virtual User? User { get; set; }
    }
}
