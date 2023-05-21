namespace RailwayManagementSystem.Models
{
    // one-to-many with Reservation
    public class Payment
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Payment_method { get; set; }
        public string Amount_paid { get; set;}
        public string Payment_status { get; set;}
        public ICollection<Reservation> Reservations { get; set; }
    }
}
