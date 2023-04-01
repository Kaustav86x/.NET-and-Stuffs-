public class Program
{
    public static Dictionary<string, string> VacancyDetail { get; set; } = new Dictionary<string, string>();

    // will add the vacancy details to the vacancydetails dictionary 
    public void AddVacancyDetails(string[] vacancy)
    {
        string[] vdetails;
        for(int i = 0; i < vacancy.Length; i++)
        {
            vdetails = vacancy[i].Split(":");
            VacancyDetail.Add(vdetails[0], vdetails[1]);
        }
    }

    public int FindTheNumberOfVacancies(string role)
    {
        //checking wheather role1 is existing in the dict or not
        /*foreach(string role in VacancyDetail.Keys) 
        {
            if()
        }*/
        int count = 0;
        /*int val = 0;*/
        foreach(var v in VacancyDetail) 
        {
            if (v.Key == role && v.Value != null)
            {
                count += 1;
            }
        }
        if(count > 0)
        {
            return count;
        }
        else { 
            return -1; 
        }
        
    }

    public List<string> FindComapanyNames(string role)
    {
        List <string> ComNames = new List<string>();
        foreach(var name in VacancyDetail)
        {
            if(name.Value == role)
            ComNames.Add(name.Key);
        }
        return ComNames;
    }

    public static void Main(string[] args)
    {
        int choice;
        string[] vacancy;
        int result = 0;
        Program p = new Program();
        
        /*Console.WriteLine("Hello, World!");*/
        while(true) 
        {
            Console.WriteLine("1.Add Vacancy Details");
            Console.WriteLine("2.View Number of Vancancies By Role");
            Console.WriteLine("3.View Company Name By Role");
            Console.WriteLine("4.Exit");
            while(true) 
            {
                Console.WriteLine("Enter the Choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice) 
                {
                    case 1: Console.WriteLine("Enter the number of entries");
                            int noOfEn = Convert.ToInt32(Console.ReadLine());
                            string[] entries = new string[noOfEn];
                            for(int i = 0; i < noOfEn; i++)
                            {
                            entries[i] = Console.ReadLine();
                            }
                            p.AddVacancyDetails(entries);
                            break;
                   case 2:  Console.WriteLine("Enter the role");
                            string role = Console.ReadLine();
                            result = p.FindTheNumberOfVacancies(role);
                            if (result == -1)
                                Console.WriteLine("No vacancies are available for the role");
                            else 
                                Console.WriteLine("Count:" +  result);
                            break; 
                    
                   case 3: Console.WriteLine("Enter the role");
                        string name = Console.ReadLine();
                        List<string> value = p.FindComapanyNames(name);   
                        if(value == null)
                        {
                            Console.WriteLine("No companies");
                        }
                        else
                        {
                            foreach(string entry in value)
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
}
