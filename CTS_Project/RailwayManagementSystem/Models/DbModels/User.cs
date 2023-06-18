using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayManagementSystem.Models.DbModels
{
    // one-to-many with Ticket_detail
    // many-to-one with Role
    // one-to-many with Payments
    public class User // child
    {
        public User() 
        {
            Reservations = new HashSet<Reservation>();
        }   
        [Required]
        public string Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "First Name length can't be more than 50.")]
        public string? Fname { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Last Name length can't be more than 50.")]
        public string? Lname { get; set;}
        [Required]
        [RegularExpression(@"^[2-9]{2}[0-9]{8}$")]
        public long Phone { get; set;}

        [Required]
        [StringLength(50, ErrorMessage = "Email length can't be more than 50.")]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$")]
        public string? Email { get; set;}
        [Required]
        public string? Password { get; set;}
        // foreign key
        [Required]
        public string? RoleId { get; set; }
        public virtual Role? Role { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; } 
    }
}
