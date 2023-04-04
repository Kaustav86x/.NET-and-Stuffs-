using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vegetable_Cost
{
    public class Service : Vegetable
    {
        public Service(string billId, string name, int gramsInPack, double costPerPack)
        {
            BillId = billId;
            Name = name;
            GramsInPack = gramsInPack;
            CostPerPack = costPerPack;
        }

    }
}
