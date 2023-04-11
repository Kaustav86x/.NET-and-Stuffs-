using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VST_Lite
{
    public class CourierDetails:Courier
    {
        public CourierDetails() { }

        public void FindServiceType()
        {
            if (DateTime.Compare(PickUpDate, DeliverDate) == 0)
                ServiceType = "Same Day";
            else if (DeliverDate.Subtract(PickUpDate).Days <= 3 && DeliverDate.Subtract(PickUpDate).Days > 0)
                ServiceType = "Express";
            else if (DeliverDate.Subtract(PickUpDate).Days > 3)
                ServiceType = "Standard";
            else if (DeliverDate.Subtract(DeliverDate).Days < 0)
                ServiceType = "Invalid";
        }

        public double CalculateDeliveryCharge()
        {
            if (ServiceType == "Same Day")
                Cost += (0.5 * Cost);
            else if (ServiceType == "Express")
                Cost += (0.3 * Cost);
            else if (ServiceType == "Standard")
                Cost = Cost + 0;

            return Cost;
        }
    }
}
