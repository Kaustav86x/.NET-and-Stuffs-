using System.ComponentModel.DataAnnotations;

namespace RailwayManagementSystem.Models.DbModels
{
    // one-to-many with Reservation
    // many-to-many with Train_details
    public class Class
    {
        public Class() 
        { 
            Train_details = new HashSet<Train_detail>();
        }
        [Required]
        public int Id { get; set; }
        [Required] 
        public string Class_type { get; set; }
        [Required]
        public int Fare { get; set; }
        [Required]
        public int SeatCapacity { get; set; }
        // foreign key
        public virtual ICollection<Train_detail> Train_details { get; set;}  
    }
}