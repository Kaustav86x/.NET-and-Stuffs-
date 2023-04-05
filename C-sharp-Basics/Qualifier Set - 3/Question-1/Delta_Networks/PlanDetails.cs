using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delta_Networks
{
    public class PlanDetails:Plan
    {
        public bool ValidatePlanType()
        {
            if (PlanType == "Annual" || PlanType == "Monthly" || PlanType == "Quarterly")
                return true;
            else
                return false;
        }

        public Plan CalculatePlanAmount() 
        {
            if (PlanType == "Monthly")
                PlanAmount = 450 - (450 * 0.1);
            else if(PlanType == "Quarterly")
                PlanAmount = 1400 - (1400 * 0.2);    
            else if(PlanType == "Annual")
                PlanAmount = 2400 - (2400 * 0.5);
            return this;
        }
    }
}
