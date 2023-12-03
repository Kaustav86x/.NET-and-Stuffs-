namespace RentaCar.Models.Domain
{
    public class User
    {
        public Guid USerId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public long? PhoneNo { get; set; }
        public ICollection<Car> Cars { get; set; }

    }
}
