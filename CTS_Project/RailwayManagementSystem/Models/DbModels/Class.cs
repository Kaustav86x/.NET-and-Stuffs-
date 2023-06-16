using System.ComponentModel.DataAnnotations;

namespace RailwayManagementSystem.Models.DbModels
{
    // one-to-many with Reservation
    // many-to-many with Train_details
    // many-to-one with Train_Detail_Class
    public class Class
    {
        [Required]
        public int Id { get; set; }
        [Required] 
        public string Class_type { get; set; }
        [Required]
        public int Fare { get; set; }
        [Required]
        public int SeatCapacity { get; set; }
        // foreign key
        public string TDCID { get; set; }
        public virtual Train_Detail_Class? Train_Detail_Classes { get; set; }
    }
}