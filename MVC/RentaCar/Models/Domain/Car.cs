namespace RentaCar.Models.Domain
{
    public class Car
    {
        public Guid CarId { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public double? Kms { get; set; }
        public double? Rating { get; set; }
        public string? Description { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
