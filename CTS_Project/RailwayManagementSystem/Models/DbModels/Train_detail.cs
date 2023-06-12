using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayManagementSystem.Models.DbModels
{
    // one-to-many with Reservation
    // many-to-many with Class
    public class Train_detail
    {
        public Train_detail()
        {
            Reservations = new HashSet<Reservation>();
            Classes = new HashSet<Class>();
        }
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Source name length can't be more than 50.")]
        public string Source { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Destination length can't be more than 50.")]
        public string Destination { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Train name length can't be more than 50.")]
        public string Train_name { get; set; }
        [Required]
        public string Arr_time { get; set; }
        [Required]
        public string Dept_time { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime DateOfDeparture { get; set; }
        [Required]
        // estimate duration of the journey
        public double Duration { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
