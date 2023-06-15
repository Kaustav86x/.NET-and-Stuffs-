using Microsoft.Identity.Client;

namespace RailwayManagementSystem.Models.AddModels
{
    public class AddTicket
    {
        public int Id { get; set; }
        public string Train_ame { get; set; }
        public string Passenger { get; set; }
        public string Class_Type { get; set; }
        public string Seat_no { get; set; }
        public DateTime Date { get; set; }
        public Guid Payment_Id { get; set; }
    }
}
