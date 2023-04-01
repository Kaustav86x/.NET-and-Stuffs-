public class Program
{
    public static void Main(string[] args)
    {
        /*Console.WriteLine("Hello, World!");*/
        Person pr = new Person();
        Console.WriteLine("Enter First Name");
        pr.FirstName = Console.ReadLine();

        Console.WriteLine("Enter Last Name");
        pr.LastName = Console.ReadLine();

        Console.WriteLine("Enter the Date of Birth in yyyy/mm/dd format");
        pr.Dob = Convert.ToDateTime(Console.ReadLine());

        pr.DisplayDetails();
    }
}

public class Person
{
    private string firstName;
    private string lastName;
    private DateTime dob;

    public string FirstName
    {
        get { return firstName; }
        set { firstName = value; }
    }

    public string LastName
    {
        get { return lastName; }
        set { lastName = value; }
    }
    public DateTime Dob
    {
        get { return dob; }
        set { dob = value; }
    }
    public string Adult
    {
        get
        {
            if (GetAge(Dob) < 18)
            {
                return "Child";
            }
            return "Adult";
        }
    }

    public int GetAge(DateTime dob)
    {
        DateTime now = DateTime.Now; // current date with time
        TimeSpan ageS = dob - now;
        int age = ageS.Days / 365;
        return age;
    }

    public void DisplayDetails()
    {
        Console.WriteLine("First Name {0}", FirstName);
        Console.WriteLine("Last Name {0}", LastName);
        Console.WriteLine("Age {0}", GetAge(Dob));
        Console.WriteLine(Adult);
    }
}
