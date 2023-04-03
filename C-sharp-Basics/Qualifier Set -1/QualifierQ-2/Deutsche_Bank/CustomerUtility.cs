using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Deutsche_Bank
{
    public class CustomerUtility : Customer
    {
        public CustomerUtility(string customerName, long ssn, string city, double lamnt, int years)
        {
            this.CustomerName = customerName;
            this.SSN = ssn;
            this.City = city;
            this.LoanAmount = lamnt;
            this.NoOfYears = years;
        }
        public string GenerateTokenNumber()
        {
            string namechar = this.CustomerName.Substring(0,2).ToUpper();
            string city = this.City.Substring(2,1).ToUpper();
            string val = this.SSN.ToString();
            string result = namechar + city + val.Substring(val.Length - 2,2);

            return result;
        }

        public double CalculateAnnualInterest(string loanType)
        {
            double annInterest = 0;
            if(loanType == "Home")
                annInterest =  this.LoanAmount * 0.03 * this.NoOfYears;
            else if (loanType == "Business")
                annInterest = this.LoanAmount * 0.05 * this.NoOfYears;
            else if(loanType == "Gold")
                annInterest = this.LoanAmount * 0.03 * this.NoOfYears;

            return annInterest;
        }
    }
}
