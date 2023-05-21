namespace RailwayManagementSystem.Models
{
    // many-to-one with User
    // many-to-one with Train_detail
    // many-to-one with Ticket_detail
    // many-to-one with Class
    // many-to-one with Payment
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        // foreign key
        public int User_id { get; set; }
        public User User { get; set; }
        /// foreign key
        public int Train_id { get; set; }
        public Train_detail Train_detail { get; set; }
        // foreign key
        public int Ticket_id { get; set; }
        public Ticket_detail Ticket_Detail { get; set; }
        // foreign key
        public int Class_id { get; set; }
        public Class Class { get; set; }
        // foreign key
        public int Payment_id { get; set; }
        public Payment Payment { get; set; }

    }
}
