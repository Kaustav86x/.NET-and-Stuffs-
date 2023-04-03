using Deutsche_Bank;

public class Program
{
    public static void Main(string[] args)
    {
        /*Console.WriteLine("Hello, World!"); */
        Console.WriteLine("Enter the customer name");
        string cust = Console.ReadLine();

        Console.WriteLine("Enter SSN(social security number)");
        long ssnum = Convert.ToInt64(Console.ReadLine());

        Console.WriteLine("Enter the city");
        string ct = Console.ReadLine();

        Console.WriteLine("Enter the total loan amount");
        double la = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter the number of years");
        int noe = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the loan type");
        string lt = Console.ReadLine(); 

        CustomerUtility cu = new CustomerUtility(cust,ssnum,ct,la,noe);

        string result = cu.GenerateTokenNumber();
        Console.WriteLine("Token number is {0}", result);

        double interest = cu.CalculateAnnualInterest(lt);
        Console.WriteLine("Annual interest is {0}", interest);

    }
}