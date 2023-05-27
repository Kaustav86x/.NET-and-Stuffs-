using System.ComponentModel.DataAnnotations;

namespace RailwayManagementSystem.Models
{
    public class Role //parent
    {
        public Role() 
        {
            Users = new HashSet<User>();
        }
        public Guid Id { get; set; }
        [Required]
        public string Role_type { get; set; }
        public virtual ICollection<User> Users { get; set;}
    }
}
