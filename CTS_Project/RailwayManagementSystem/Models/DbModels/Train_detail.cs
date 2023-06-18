using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RailwayManagementSystem.Models.DbModels
{
    // one-to-many with Reservation
    // many-to-many with Class
    // many-to-one with Train_detail_class
    public class Train_detail
    {
        public Train_detail()
        {
            Reservations = new HashSet<Reservation>();
        }
        [Required]
        public string Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Source name length can't be more than 50.")]
        public string? Source { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Destination length can't be more than 50.")]
        public string? Destination { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Train name length can't be more than 50.")]
        public string? Train_name { get; set; }
        [Required]
        public string? Arr_time { get; set; }
        [Required]
        public string? Dept_time { get; set; }
        [Required]
        [Column(TypeName = "date")]
        public DateTime DateOfDeparture { get; set; }
        [Required]
        public int AvailableSeats { get; set; }
        // estimate duration of the journey
        [Required]
        public double Duration { get; set; }
        public string? TDCID { get; set; }
        public virtual Train_Detail_Class? Train_Detail_Classes { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; }
    }
}
