using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstCS
{
    class Program
    {
        static void Main(string[] args) // starts execution
            //=> Console.WriteLine("hello, I am Kaustav Dey");
        {

            /* string name = "Kevin";
            int age = 35;
            char grade = 'A';
            double gpa = 3.589;
            bool isMale = true;

            Console.WriteLine("Hello, I am kaustav Dey");
            Console.WriteLine("hey, My gaming name is " + name);
            Console.WriteLine("My age is " + age);
            Console.WriteLine(grade);
            Console.WriteLine(gpa);
            Console.WriteLine(isMale);
            Console.WriteLine(name.Length); // length of the string
            Console.WriteLine(name.ToUpper());
            Console.WriteLine(grade.ToString().ToLower());
            Console.WriteLine(grade.ToString().ToLower());
            Console.WriteLine(name.Contains("vin")); // cheecking substring
            Console.WriteLine(name[0]);
            Console.WriteLine(name.IndexOf('I')); // returns -1 if doesn't match
            Console.WriteLine(name.Substring(4));
            Console.WriteLine(Math.Abs(-56)); // Math module
            // user input
            Console.Write("Enter a line : ");
            string str = Console.ReadLine();
            Console.WriteLine(str);
            Console.WriteLine("45" + "10" + 10);
            // string to number
            int num1 = Convert.ToInt32("30");
            int num2 = Convert.ToInt16("30");
            // int num3 = Convert.ToInt64("30");
            Console.WriteLine(num1);
            Console.WriteLine(num2);

            Console.WriteLine();
            Console.WriteLine();


            Console.WriteLine(); */

            /*Console.Write("Enter your name:");
            string name = Console.ReadLine();

            Console.Write("Enter the age:");
            int age = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter the country:");
            string country = Console.ReadLine();

            Console.Write("Welcome " + name + ". Your age is " + age + " and you are from " + country); */

            /*string name = Console.ReadLine();
            string[] words = name.Split(' ');
            int len = words.Length;
            for(int i = len-1; i<)*/

            /*DateTime dt;
            Console.WriteLine("Enter date and time");
            dt = Convert.ToDateTime(Console.ReadLine());
            Console.Write(dt); */

            /*DateTime date1 = DateTime.Now;
            DateTime date2 = Convert.ToDateTime(Console.ReadLine());
            var today = date1 - date2;
            var age = today.Days / 365;
            Console.WriteLine(age);*/

            long l = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine(l);

            //feime dt1= DateTime.Now;  // returns current date and time
            //DateTime dt2 = DateTime.Today; // returns the current date but not the time
            // Console.Write(dt2);

            Console.ReadLine(); // to hold the output window
        }
        
    }
}
