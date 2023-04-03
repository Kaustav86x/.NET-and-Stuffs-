using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Travel_Cost
{
    public bool ValidateTravelId(string travelId)
    {

    }
    public double CalculateDiscountCost()
    {

    }
    public class Service : Travel
    {
        public Service(string travelID, string departureId, string destinationPlace, int noOfDays, double costPerDay)
        {
            TravelId = travelID;
            DeparturePlace = departureId;
            DestinationPlace = destinationPlace;
            NoOfDays = noOfDays;
            CostPerDay = costPerDay;
        }
    }
}
