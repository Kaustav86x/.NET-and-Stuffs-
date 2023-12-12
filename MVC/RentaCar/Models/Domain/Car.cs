using System.ComponentModel.DataAnnotations;

namespace RentaCar.Models.Domain
{
    public class Car
    {
        public Guid CarId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Type { get; set; }
        [Required]
        public double? Kms { get; set; }
        [Required]
        public double? Rating { get; set; }
        [Required]
        public string? Description { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
