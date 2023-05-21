namespace RailwayManagementSystem.Models
{
    // many-to-one with User
    // one-to-many with Reservation
    public class Ticket_detail
    {
        public int Id { get; set; }
        public string Train_name { get; set; }
        public string Pass_name { get;}
        public string class_type { get; set; }
        public string Seat_no { get; set;}
        public DateTime Date { get; set;}
        public int Fare { get; set;}
        //foreign key
        /*public int User_id { get; set; }
        public User User { get; set; }
        public ICollection<Reservation> Reservations { get; set; }*/
    }
}
