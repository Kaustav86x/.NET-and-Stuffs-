using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phoenix_Club
{
    public class Player
    {
        public string Number { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string InterestedIn { get; set; }

        public Player() { } 

        public Player(string number, string name, int age, string interestedIn)
        {
            this.Number = number;
            this.Name = name;
            this.Age = age;
            this.InterestedIn = interestedIn;
        }
    }
}
