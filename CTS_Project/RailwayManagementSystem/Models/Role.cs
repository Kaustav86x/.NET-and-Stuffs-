namespace RailwayManagementSystem.Models
{
    // one-to-one with User
    public class Role
    {
        public int Id { get; set; }
        public string Role_Type { get; set; }
        public virtual User User { get; set; }
    }
}
