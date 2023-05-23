namespace RailwayManagementSystem.Models
{
    public class Role //parent
    {
        public int Id { get; set; }
        public string Role_type { get; set; }
        public User? User { get; set; }
    }
}
