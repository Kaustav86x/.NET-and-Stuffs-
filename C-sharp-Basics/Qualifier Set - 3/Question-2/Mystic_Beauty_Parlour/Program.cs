using Mystic_Beauty_Parlour;

public class Program
{
    public static Queue<Customer> CustomerQueue { get; set; } = new Queue<Customer>();
    public static void Main(string[] args)
    {
        Customer cust = new Customer();
        int choice;
        /*Console.WriteLine("Hello, World!");*/
        while (true) 
        {
            Console.WriteLine("Choose the option");
            Console.WriteLine("1.Add the customer details");
            Console.WriteLine("2.Get customer name with service");
            Console.WriteLine("3.Remove customer details");
            Console.WriteLine("4.Exit");
            choice = Convert.ToInt32(Console.ReadLine());
            switch(choice)
            {
                case 1:
                    Console.WriteLine("Enter the customer name");
                    string cname = Console.ReadLine();
                    Console.WriteLine("Enter the mobile number");
                    long mno = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("Enter the city");
                    string ct = Console.ReadLine();
                    Console.WriteLine("Enter the service");
                    string srvc = Console.ReadLine();
                    /*Customer cust = new Customer()*/
                    bool conf = cust.AddCustomer(cname, mno, ct, srvc);
                    if(conf)
                        Console.WriteLine("Customer details added successfully");
                    break;
                case 2:
                    string result = cust.GetCustomerNameWithService();
                    Console.WriteLine(result);
                    break;
                case 3:
                    Console.WriteLine("Enter the mobile number");
                    long mnum = Convert.ToInt64(Console.ReadLine());
                    Queue<Customer> val = new Queue<Customer>();
                    val = cust.RemoveCustomerDetails(mnum);
                    if (val.Count == 0)
                        Console.WriteLine("No data found");
                    else
                    {
                        foreach (Customer item in val.ToList())
                            Console.WriteLine("{0} {1} {2} {3}",item.CustomerName, item.MobileNumber, item.City, item.Service);
                    }
                    break;
                case 4:
                    Console.WriteLine("Thank you");
                    return;
                default:
                    Console.WriteLine("Wrong choice");
                    break;

            }
        }

    }
}