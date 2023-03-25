using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCS
{
    class Class1
    {
        // using the concepts of reading file 
        public static void main(string[] args)
        {
            string filecontent = System.IO.File.ReadAllText("@C:/Users/HPDownloads/input.txt");
            Console.WriteLine(filecontent);

            Console.ReadLine();
        }
    }
}
