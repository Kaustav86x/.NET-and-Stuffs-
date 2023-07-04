using RailwayManagementSystem.Models.DbModels;

namespace RailwayManagementSystem.Models.AddModels
{
    public class AddTrains
    {
        //public string Id { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Train_name { get; set; }
        public string Arr_time { get; set; }
        public string Dept_time { get; set; }
        public double Duration { get; set; }
        public DateTime DateOfDeparture { get; set; }
        public string TDC { get; set; }
        public int Available_Seats { get; set; }

    }
}
