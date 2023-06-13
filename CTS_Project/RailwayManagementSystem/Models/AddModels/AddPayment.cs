using RailwayManagementSystem.Models.DbModels;

namespace RailwayManagementSystem.Models.AddModels
{
    public class AddPayment
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string? Payment_method { get; set; }
        public string? Payment_status { get; set; }
        public int Class_Id { get; set; }
        public string? Reservation_Id { get; set; }
    }
}
