using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VST_Lite
{
    public class Courier
    {
        public DateTime PickUpDate { get; set; }
        public DateTime DeliverDate { get; set; }
        public string ServiceType { get; set; }
        public double Cost { get; set; }
    }
}
