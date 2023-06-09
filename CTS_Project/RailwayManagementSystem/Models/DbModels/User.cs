using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayManagementSystem.Models.DbModels
{
    // one-to-many with Ticket_detail
    // one-to-one with Role
    // one-to-many with Payments
    public class User // child
    {
        public User() 
        {
            Ticket_Details = new HashSet<Ticket_detail>();
            Reservations = new HashSet<Reservation>();
            Payments = new HashSet<Payment>();
        }   
        [Required]
        public string Id { get; set; }
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set;}
        [Required]
        public long Phone { get; set;}
        [Required]
        public string Email { get; set;}
        [Required]
        public string Password { get; set;}
        // foreign key
        [Required]
        public string RoleId { get; set; }
        public virtual Role? Role { get; set; }
        public virtual ICollection<Ticket_detail> Ticket_Details { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; } 
        // a user can conduct multiple payments
        public virtual ICollection<Payment> Payments { get; set; }    
    }
}
