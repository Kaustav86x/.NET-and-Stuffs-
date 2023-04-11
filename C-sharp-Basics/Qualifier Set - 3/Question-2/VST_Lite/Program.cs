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

        Console.WriteLine("")
    }
}