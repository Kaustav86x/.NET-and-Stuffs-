using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayManagementSystem.Models
{
    // one-to-many with Ticket_detail
    // one-to-one with Role
    public class User // child
    {
        /*[ForeignKey("Role")]*/
        [Required]
        public Guid Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Fname { get; set; }
        [MaxLength(50)]
        public string Lname { get; set;}
        [Required]
        public long Phone { get; set;}
        [Required]
        public string Email { get; set;}
        // foreign key
        public Guid Role_id { get; set; }
        public Role Role { get; set; }
        public ICollection<Ticket_detail> Ticket_Details { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
