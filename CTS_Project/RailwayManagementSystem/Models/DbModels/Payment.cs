using System.ComponentModel.DataAnnotations;

namespace RailwayManagementSystem.Models.DbModels
{
    // one-to-one with Reservation
    // many-to-one with User
    public class Payment
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        [Required]
        public string? Payment_method { get; set; }
        [Required]
        public string? Payment_status { get; set; } 
        // public virtual Class? Class { get; set; }
        public string? Reservation_Id { get; set; }
        public virtual Reservation? Reservations { get; set; }
        public int? TicketId { get; set; }
        public virtual Ticket_detail? Ticket_Details { get; set; }
    }
}
