using System.ComponentModel.DataAnnotations;

namespace RealEstateAPI.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Name must not be null")]
        public string Name { get; set; }
        [Required(ErrorMessage = "ImageUrl must not be null")]
        public string ImageUrl { get; set; }
        // one-to-many relationship with Category table
        public ICollection<Property> Properties { get; set; }
    }
}
