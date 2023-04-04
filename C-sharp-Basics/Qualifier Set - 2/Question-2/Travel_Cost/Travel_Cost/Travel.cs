using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_Cost
{
    public class Travel
    {
        public string TravelId { get; set; }
        public string DeparturePlace { get; set; }
        public string DestinationPlace { get; set; }
        public int NoOfDays { get; set; }
        public double CostPerDay { get; set; }

        public Travel() { }
    }
}
