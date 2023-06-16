using Microsoft.Build.Framework;

namespace RailwayManagementSystem.Models.DbModels
{
    public class Train_Detail_Class
    {
        // one-to-many with Train_details
        // one-to-many Class
        public Train_Detail_Class()
        {
            TrainDetails = new HashSet<Train_detail>();
            Classes = new HashSet<Class>();
        }
        [Required]
        public string TDC_Id { get; set; }
        public virtual ICollection<Train_detail> TrainDetails { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
