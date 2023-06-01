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
        public string User_name { get; set; }
        [Required]
        public int Total_fare { get; set;}
        [Required] 
        public DateTime Date { get; set; }
        // foreign key
        [Required]
        public string User_id { get; set; }
        public virtual User? User { get; set; }
        // foreign key 
        [Required]
        public int Train_id { get; set; }
        public virtual Train_detail? Train_detail { get; set; }
        // foreign key
        [Required]
        public int Class_id { get; set; }
        public virtual Class? Class { get; set; }
        // foreign key
        [Required]
        public Guid Payment_id { get; set; }
        public virtual Payment? Payment { get; set; }
    }
}
