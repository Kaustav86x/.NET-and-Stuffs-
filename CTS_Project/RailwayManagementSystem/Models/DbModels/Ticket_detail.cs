using System.ComponentModel.DataAnnotations;

namespace RailwayManagementSystem.Models.DbModels
{
    // many-to-one with User
    public class Ticket_detail
    {
        public string Id { get; set; }
        [Required]
        public string? Train_name { get; set; }
        [Required]
        public string? Passenger { get; set; }
        [Required]
        // some trains don't have a class specification
        public string? Class_type { get; set; }
        [Required]
        public string? Seat_no { get; set;}
        [Required]
        public DateTime Date { get; set;}
        // foreign key
        public Guid PaymentId { get; set; }
        public Payment? Payment { get; set; }

    }
}
