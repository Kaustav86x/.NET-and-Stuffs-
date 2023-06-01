using System.ComponentModel.DataAnnotations;

namespace RailwayManagementSystem.Models.DbModels
{
    public class Role //parent
    {
        public Role() 
        {
            Users = new HashSet<User>();
        }
        [Required]
        public string Id { get; set; }
        [Required]
        public string? Role_type { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
