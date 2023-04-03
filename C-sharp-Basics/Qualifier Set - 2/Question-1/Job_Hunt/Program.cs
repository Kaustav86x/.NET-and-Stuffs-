using System.Security.Cryptography.X509Certificates;

public class Program
{
    public static Dictionary<string, string> VacancyDetails { get; set; } = new Dictionary<string, string>();

    public void AddVacancyDetails(string[] vacancy)
    {
        foreach (string str in vacancy)
        {
            string[] entry = str.Split(':');
            VacancyDetails.Add(entry[0], entry[1]);
        }
        Console.WriteLine("Details Added");
    }

    public int FindTheNumberOfVacancies(string role)
    {
        int count = 0;
        foreach (var item in VacancyDetails.Values) 
        {
            if (item.Equals(role))
                count += 1;
        }
        if(count > 0) 
        { 
            return count;
        }
        else { return -1; }
    }

    public List<string> FindCompanyNames(string role) 
    {
        // we need to add company names to a list
        List<string> list = new List<string>();
        string temp = "";
        foreach(var item in VacancyDetails)
        {
            temp = item.Value;
            if (temp.Equals(role))
                list.Add(item.Key);
        }
        return list;
    }
    public static void Main(string[] args)
    {
        int choice;
        string[] vacancy;
        int result = 0;
        Program p = new Program();

        while (true)
        {
            Console.WriteLine("1.Add Vacancy Details");
            Console.WriteLine("2.View Number of Vancancies By Role");
            Console.WriteLine("3.View Company Name By Role");
            Console.WriteLine("4.Exit");
            Console.WriteLine("Enter the choice");
            choice = Convert.ToInt32(Console.ReadLine()); 
            switch(choice)
            {
                case 1:
                    Console.WriteLine("Enter the number of entries");
                    int noOfEn = Convert.ToInt32(Console.ReadLine());
                    string[] entries = new string[noOfEn];
                    for (int i = 0; i < noOfEn; i++)
                    {
                        entries[i] = Console.ReadLine();
                    }
                    p.AddVacancyDetails(entries);
                    break;
                case 2:
                    Console.WriteLine("Enter the role");
                    string role = Console.ReadLine();
                    result = p.FindTheNumberOfVacancies(role);
                    if (result == -1)
                        Console.WriteLine("No vacancies are available for the role");
                    else
                        Console.WriteLine("No of vacancies by role is - {0}",count);
                    break;
                case 3:
                    Console.WriteLine("Enter the role");
                    string name = Console.ReadLine();
                    List<string> value = p.FindCompanyNames(name);
                    if (value == null)
                    {
                        Console.WriteLine("No companies");
                    }
                    else
                    {
                        foreach (string entry in value)
                        {
                            Console.WriteLine(entry);
                        }
                    }
                    break;
                case 4: return;
            }
        }
    }
}