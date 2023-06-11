using RailwayManagementSystem.Models.DbModels;

namespace RailwayManagementSystem.Models.AddModels
{
    public class AddTrains
    {
        //public int Id { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public string Train_name { get; set; }
        public string Arr_time { get; set; }
        public string Dept_time { get; set; }
        public DateTime Date { get; set; }
    }
}
