namespace RailwayManagementSystem.Models.AddModels
{
    public class AddReservation
    {
        public string Id { get; set; }
        public string Passenger { get; set; }
        public DateTime Date { get; set; }
        public string UserId { get; set; }
        public string TrainId { get; set; }
    }
}
