using System.ComponentModel.DataAnnotations;

namespace RailwayManagementSystem.Models
{
    public class Role //parent
    {
        [Required]
        public Guid Id { get; set; }
        [MaxLength(50)]
        public string Role_type { get; set; }
        public ICollection<User> Users { get; set;}
    }
}
