using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace RailwayManagementSystem.Models
{
    // one-to-many with Reservation
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
        public DateTime Arr_time { get;}
        [Required]
        public DateTime Dept_time { get; set; }
        [Required]
        public string Class_available { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
