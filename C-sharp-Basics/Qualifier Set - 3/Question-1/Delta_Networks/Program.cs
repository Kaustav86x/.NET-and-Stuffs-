using Delta_Networks;

public class Program
{
    public static void Main(string[] args)
    {
        PlanDetails pd = new PlanDetails();
        /*Console.WriteLine("Hello, World!");*/
        Console.WriteLine("Enter the plan type");
        pd.PlanType = Console.ReadLine();
        if (pd.ValidatePlanType())
        {
            Plan p = pd.CalculatePlanAmount();
            Console.WriteLine("Plan type is {0}\nPlan amount is {1}", p.PlanType, p.PlanAmount);
        }
        else
            Console.WriteLine("Invalid plan");
    }
}