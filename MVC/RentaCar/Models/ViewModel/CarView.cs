using System.ComponentModel;

namespace RentaCar.Models.ViewModel
{
    public class CarView
    {
        [DisplayName("Car Model")]
        public string? Name { get; set; }
        [DisplayName("Car Type")]
        public string? Type { get; set; }
        [DisplayName("Travelled in KM")]
        public double? Kms { get; set; }
        public double? Rating { get; set; }
        public string? Description { get; set; }
    }
}
