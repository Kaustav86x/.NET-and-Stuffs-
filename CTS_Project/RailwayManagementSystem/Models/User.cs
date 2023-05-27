using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayManagementSystem.Models
{
    // one-to-many with Ticket_detail
    // one-to-one with Role
    public class User // child
    {
        public User() 
        {
            Ticket_Details = new HashSet<Ticket_detail>();
            Reservations = new HashSet<Reservation>();
        }   
        /*[ForeignKey("Role")]*/
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Fname { get; set; }
        [Required]
        public string Lname { get; set;}
        [Required]
        public long Phone { get; set;}
        [Required]
        public string Email { get; set;}
        // foreign key
        [Required]
        public Guid Role_id { get; set; }
        public virtual Role? Role { get; set; }
        public virtual ICollection<Ticket_detail> Ticket_Details { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
