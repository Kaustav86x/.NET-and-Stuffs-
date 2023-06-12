using System.ComponentModel.DataAnnotations;

namespace RailwayManagementSystem.Models.DbModels
{
    // many-to-one with User
    // many-to-one with Train_detail
    // many-to-one with Class
    // many-to-one with Payment
    public class Reservation
    {
        public string Id { get; set; }
        [Required]
        public string? Passenger { get; set; }
        [Required] 
        public DateTime Date { get; set; }
        // foreign key
        public string? UserId { get; set; }
        public virtual User? User { get; set; }
        // foreign key 
        public int TrainId { get; set; }
        public virtual Train_detail? Train_detail { get; set; }
        // foreign key
        public virtual Payment? Payment { get; set; }
    }
}
