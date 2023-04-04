using System.Diagnostics.Metrics;
namespace Travel_Cost
{
    public class Program
    {

        public static void Main(string[] args)
        {
            double result = 0.0;
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

            Service srvc = new Service(tid, depplace, despalce, noofdays, cost);
            if(srvc.ValidateTravelId(tid)) 
            {
                result = srvc.CalculateDiscountCost();
                Console.WriteLine("Discounted Cost {0}", result);
            }
            else
            {
                Console.WriteLine("Invalid travel id");
            }
        }
    }
}