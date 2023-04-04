using Vegetable_Cost;

public class Program
{
    public static void Main(string[] args)
    {
        double result = 0.0;
        Service srvc = new Service();

        /*Console.WriteLine("Hello, World!");*/
        Console.WriteLine("Enter bill id");
        srvc.BillId = Console.ReadLine();
        if(srvc.ValidateBillId())
        {
            Console.WriteLine("Enter Vegetable name");
            srvc.Name = Console.ReadLine();
            Console.WriteLine("Enter pack capacity in grams");
            srvc.GramsInPack = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter cost per pack");
            srvc.CostPerPack = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter quantity to purchase in kgs");
            float q = float.Parse(Console.ReadLine());
            result = srvc.CalculateTotalCost(q);
            Console.WriteLine("Vegetable cost Rs.{0}", result);
        }
        else
            Console.WriteLine("Invalid bill id");
    }
}