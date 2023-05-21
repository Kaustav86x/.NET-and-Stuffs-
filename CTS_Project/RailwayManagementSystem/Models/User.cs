using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayManagementSystem.Models
{
    // one-to-many with Ticket_detail
    // one-to-one with Role
    public class User
    {
        [ForeignKey("Role")]
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set;}
        public long Phone { get; set;}
        public string Email { get; set;}
        // foreign key
        /*public virtual Role Role { get; set; }

        // foreign key
        public ICollection<Ticket_detail> Ticket_Details { get; set;}*/
    }
}
