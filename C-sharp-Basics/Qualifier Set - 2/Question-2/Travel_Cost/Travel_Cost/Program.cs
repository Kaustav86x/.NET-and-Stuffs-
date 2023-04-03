using System.Diagnostics.Metrics;
namespace Travel_Cost
{
    public class Program
    {

        public static void Main(string[] args)
        {
            /*Console.WriteLine("Hello, World!");*/
            Console.WriteLine("Enter the travel id");
            string tid = Console.ReadLine();
            Console.WriteLine("Enter the departure place");
            string depplace = Console.ReadLine();
            Console.WriteLine("Enter the destination place");
            string despalce = Console.ReadLine();
            Console.WriteLine("Enter the no of days");
            int noofdays = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the cost per day");
            double cost = Convert.ToDouble(Console.ReadLine());

            Travel trv = new Travel(tid, depplace, despalce, noofdays, cost);
        }
    }
}