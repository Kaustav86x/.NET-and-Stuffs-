namespace RealEstateAPI.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }   
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Password { get; set; }
        // establishes one-to-many realationship with Property table
        public ICollection<Property> Properties { get; set; }
        
    }
}
