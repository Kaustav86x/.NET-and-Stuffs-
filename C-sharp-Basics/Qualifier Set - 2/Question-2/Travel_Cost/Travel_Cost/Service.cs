using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Travel_Cost
{
    public class Service : Travel
    {
        public bool ValidateTravelId(string travelId)
        {
            string depplace = DeparturePlace.Substring(0, 3).ToUpper(); // starting from 0th index and picking 3 characters
            string desplace = DestinationPlace.Substring(0,3).ToUpper();
            string result = depplace + "/" + desplace;
            if (String.Equals(result, travelId))
                return true;
            else 
                return false;   
        }
        public double CalculateDiscountCost()
        {
            double discounted_cost = 0.0;
            double DiscountPercentage = 0.0;
            //discounted_cost = (CostPerDay * NoOfDays) - ((CostPerDay * NoOfDays) * Dis;
            if (NoOfDays <= 5)
                DiscountPercentage = 0;
            else if (NoOfDays > 5 && NoOfDays <= 8)
                DiscountPercentage = 0.03;
            else if (NoOfDays > 8 && NoOfDays <= 10)
                DiscountPercentage = 0.05;
            else if (NoOfDays > 10)
                DiscountPercentage = 0.07;

            discounted_cost = (CostPerDay * NoOfDays) - ((CostPerDay * NoOfDays) * DiscountPercentage);

            return discounted_cost;
        }
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
