using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORMp_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var context = new DOTNETFSE2270345Entities();
            var emp = new Emp()
            {
                EmpID = 10,
                fname = "Kaustav",
                lname = "Dey",
                jobd = "Full Stack Developer",
            };
            context.Emps.Add(emp);
            context.SaveChanges();
        }
    }
}
