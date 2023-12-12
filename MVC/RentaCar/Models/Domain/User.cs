using System.ComponentModel.DataAnnotations;

namespace RentaCar.Models.Domain
{
    public class User
    {
        public Guid UserId { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public long? PhoneNo { get; set; }
        public ICollection<Car> Cars { get; set; }

    }
}
