using Phoenix_Club;

public class Program
{
    public static List<Player> PlayerList { get; set; } = new List<Player>();
    public void AddPlayerDetails(string[] playerDetails)
    {
        string[] val = playerDetails[0].Split(':');
        Player p = new Player(val[0], val[1], int.Parse(val[2]), val[3]) ;
        PlayerList.Add(p);
    }
    public int FindCountOfPlayersByAge(int age)
    {
        int count = 0;
        foreach (Player p in PlayerList) 
        {
            if (p.Age < age)
                count++;
        }
        if (count > 0)
            return count;
        else
            return 0;
    }

    public List<Player> ViewDetailsByInterestedIn(string interestedIn)
    {
        List<Player> list = new List<Player>(); // temporary list
        foreach(Player p in PlayerList)
        {
            if (p.InterestedIn.Equals(interestedIn))
                list.Add(p);
        }
        return list;
    }
    public static void Main(string[] args)
    {
        Program prog = new Program();
        /*Console.WriteLine("Hello, World!");*/
        Console.WriteLine("1.Add Player Details");
        Console.WriteLine("2.Find Count by Age");
        Console.WriteLine("3.View Details By Interested In");
        Console.WriteLine("4.Exit");
        while (true)
        {
            Console.WriteLine("Enter the Choice");
            int v = Convert.ToInt32(Console.ReadLine());
            int choice = v;
            switch(choice)
            {
                case 1:
                    Console.WriteLine("Enter the number of entries");
                    int entry = Convert.ToInt32(Console.ReadLine());
                    string[] entries = new string[entry];
                    for(int i=0; i<entries.Length; i++)
                    {
                        entries[i] = Console.ReadLine();
                    }
                    prog.AddPlayerDetails(entries);
                    break;
                case 2:
                    Console.WriteLine("Enter the age");
                    int age = Convert.ToInt32(Console.ReadLine());
                    int total_count = prog.FindCountOfPlayersByAge(age);
                    if(total_count == 0) 
                    {
                        Console.WriteLine("Player not found");
                    }
                    else
                    {
                        Console.WriteLine("The player below {0} is {1}", age, total_count);
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter the interested in");
                    string inter = Console.ReadLine();
                    List<Player> list = new List<Player>();
                    list = prog.ViewDetailsByInterestedIn(inter);
                    foreach (Player p in list)
                        Console.WriteLine("{0} {1} {2} {3}", p.Number, p.Name, p.Age, p.InterestedIn);
                    break;
                case 4:
                    return;

            }
        }
    }
}