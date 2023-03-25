using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_sharp_Basics
{
    class Program
    {
        static void Main(string[] args)
        {

            string content = System.IO.File.ReadAllText(@"C:\Users\HP\Downloads\input.txt");
            Console.WriteLine(content);

            Console.ReadLine();
        }
    }
}
