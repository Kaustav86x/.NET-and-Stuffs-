using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Appliance
{
    public class Appliance
    {
        public string Id { get; set; }
        public string Name { get; set;  }
        public string Brand { get; set; }
        public double Price { get; set; }

        public Appliance(string id, string name, string brand, double price) 
        {
            Id = id;
            Name = name;
            Brand = brand;
            Price = price;
        }

    }
}
