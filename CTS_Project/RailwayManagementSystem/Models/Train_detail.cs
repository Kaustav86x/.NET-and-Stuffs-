using Microsoft.Identity.Client;
using System.ComponentModel.DataAnnotations;

namespace RailwayManagementSystem.Models
{
    // one-to-many with Reservation
    public class Train_detail
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Train_name { get; set; }
        public string Arr_time { get;}
        public string Dept_time { get; set; }
        public string Class_available { get; set; }
        public ICollection<Reservation> Reservations { get; set; }
    }
}
