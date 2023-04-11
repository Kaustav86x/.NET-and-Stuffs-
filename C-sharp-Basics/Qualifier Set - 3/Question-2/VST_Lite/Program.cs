using VST_Lite;

public class Program
{
    private static void Main(string[] args)
    {
        CourierDetails cd = new CourierDetails();
        /*Console.WriteLine("Hello, World!");*/
        Console.WriteLine("Enter the pickup date");
        string pdate = Console.ReadLine();
        cd.PickUpDate = DateTime.ParseExact(pdate, "m/d/yyyy", null);

        Console.WriteLine("Enter the delivery date");
        string ddate = Console.ReadLine();
        cd.DeliverDate = DateTime.ParseExact(ddate, "m/d/yyyy", null);

        cd.FindServiceType();

        if (cd.ServiceType == "Invalid")
            Console.WriteLine("Invalid Delivery date");
        else
        {
            Console.WriteLine("Enter the cost");
            cd.Cost = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("The delivery charge is {0}", cd.CalculateDeliveryCharge());
        }
    }
}