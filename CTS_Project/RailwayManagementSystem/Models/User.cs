﻿using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayManagementSystem.Models
{
    // one-to-many with Ticket_detail
    // one-to-one with Role
    public class User // child
    {
        /*[ForeignKey("Role")]*/
        public int Id { get; set; }
        public string Fname { get; set; }
        public string Lname { get; set;}
        public long Phone { get; set;}
        public string Email { get; set;}
        // foreign key
        public int Role_id { get; set; }
        public Role Role { get; set; }
        public ICollection<Ticket_detail> Ticket_Details { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
