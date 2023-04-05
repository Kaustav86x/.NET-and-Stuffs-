using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vitality_Health
{
    public class Vaccine
    {
        public string BookingId { get; set; }
        public string Name { get; set; }
        public string VaccineType { get; set; }
        public string DoseNumber {get; set; }
        public string BookingDate { get; set; }

        public Vaccine() { }

        public Vaccine(string bookingId, string name, string vaccineType, string doseNumber,  string bookingDate)
        {
            this.BookingId = bookingId;
            this.Name = name;
            this.VaccineType = VaccineType;
            this.DoseNumber = doseNumber;
            this.BookingDate = bookingDate;
        }
    }
}
