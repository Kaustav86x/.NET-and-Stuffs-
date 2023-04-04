using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Vegetable_Cost
{
    public class Service : Vegetable
    {
        public Service() { }
        /*public Service(string billId, string name, int gramsInPack, double costPerPack)
        {
            BillId = billId;
            Name = name;
            GramsInPack = gramsInPack;
            CostPerPack = costPerPack;
        }*/

        public bool ValidateBillId()
        {
            int vBil = 0;
            bool digi_check = false;
            if (BillId.Length == 7)
            {
                /*for(int i = 0; i < BillId.Substring(0, 3).Length; i++)
                {
                    if (char.IsNumber(BillId.Substring(0, 3).ElementAt(i)))
                        digi_check = true;
                    else
                        digi_check = false;
                }*/
                if(Regex.IsMatch(BillId.Substring(0,3), "^[0-9]*$"))
                    digi_check = true;
                else
                    digi_check = false;

                bool char_check = false;
                if (Regex.IsMatch(BillId.Substring(4, 3), "^[A-Z]*$"))
                    char_check = true;
                else
                    char_check = false;
                if (digi_check && char_check && BillId.ElementAt(3) == '-')
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
        public double CalculateTotalCost(float quantity)
        {
            double Total_cost = (CostPerPack * (quantity * 1000) / GramsInPack);
            return Total_cost;
        }

    }
}
