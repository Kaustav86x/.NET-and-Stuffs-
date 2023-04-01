internal class Program
{
    private static void Main(string[] args)
    {
        // declaration and initialised to space
        string name = "";
        DateTime dt;
        string jd = "";
        Console.WriteLine("Enter the name");
        name = Console.ReadLine();
        Console.WriteLine("Enter the datetime");
        dt = Convert.ToDateTime(Console.ReadLine());
        Console.WriteLine("Enter the job description");
        jd = Console.ReadLine();

        // parameterized constructor
        Domain dm = new Domain(name, dt, jd);
        {
            this.name = name;
            this.dt = new DateTime();
        }
    }
}

public class Domain
{
    private string name;
    private DateTime date;
    private string jobdc;

    // string daat = date.ToString();

    // properties 
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public DateTime Date
    {
        get { return date; }
        set { date = value; }
    }

    public string Jobdc
    {
        get { return jobdc; }
        set { jobdc = value; }
    }

    public Domain()
    {
    }

    public Domain(string name, DateTime date, string jobdc)
    {
        this.name = name;
        this.date = date;
        this.jobdc = jobdc;
    }
}

