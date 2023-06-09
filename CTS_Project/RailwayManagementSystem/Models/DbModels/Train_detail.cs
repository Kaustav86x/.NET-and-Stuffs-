using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace RailwayManagementSystem.Models.DbModels
{
    // one-to-many with Reservation
    // one-to-many with Class
    public class Train_detail
    {
        public Train_detail()
        {
            Reservations = new HashSet<Reservation>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        public string Source { get; set; }
        [Required]
        public string Destination { get; set; }
        [Required]
        public string Train_name { get; set; }
        [Required]
        public string Arr_time { get; set; }
        [Required]
        public string Dept_time { get; set; }
        [Required]
        public DateTime Date { get; set; }
        //public string ClassId { get; set; }
        public virtual Class? Class { get; set; }  
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
