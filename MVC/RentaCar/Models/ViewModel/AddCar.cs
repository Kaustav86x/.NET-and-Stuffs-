using System.ComponentModel.DataAnnotations;

namespace RentaCar.Models.ViewModel
{
    public class AddCar
    {
        public string? Name { get; set; }
        public string? Type { get; set; }
        public double? Kms { get; set; }
        public double? Rating { get; set; }
        public string? Description { get; set; }
    }
}
