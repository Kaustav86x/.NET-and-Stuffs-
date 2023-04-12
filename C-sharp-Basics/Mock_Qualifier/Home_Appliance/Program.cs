namespace Home_Appliance
{
    public class Program
    {
        public static Dictionary<int, Appliance> applianceDetails { get; set; } = new Dictionary<int, Appliance>();

        public Dictionary<string, string> GetApplianceDetails(string applianceId)
        {
            Dictionary<string, string> details = new Dictionary<string, string>();
            foreach (Appliance app in applianceDetails.Values)
            {
                if (app.Id == applianceId)
                    details.Add(app.Id, (app.Name + "_" + app.Brand));
            }
            return details;
        }

        public Dictionary<string, string> FindApplianceWithPriceRange(double minRange, double maxRange)
        {
            double max = double.MinValue;
            foreach (Appliance app in applianceDetails.Values)
            {
                if (app.Price >= max)
                    max = app.Price;
            }
            Dictionary<string, string> result = new Dictionary<string, string>();
            foreach (Appliance app in applianceDetails.Values)
            {
                if (app.Price <= maxRange && app.Price >= minRange)
                    result.Add(app.Name, app.Brand);
            }
            return result;
        }

        public Dictionary<int,Appliance> FindHighCostAppliance()
        {
            Dictionary<int, Appliance> mDict = new Dictionary<int, Appliance>();
            double max = double.MinValue;
            foreach (Appliance app in applianceDetails.Values)
            {
                if (app.Price >= max)
                    max = app.Price;
            }
            foreach(KeyValuePair<int,Appliance> app in applianceDetails)
            {
                if (app.Value.Price == max)
                    mDict.Add(app.Key, app.Value);
            }
            return mDict;
        }
        public static void Main(string[] args)
        {
            Program pr = new Program();
            applianceDetails.Add(1, new Appliance("A01", "Refrigerator", "LG", 14000));
            applianceDetails.Add(2, new Appliance("A02", "Washing Machine", "LG", 34000));
            applianceDetails.Add(3, new Appliance("A03", "Oven", "Bajaj", 8000));
            /*applianceDetails.Add(4, new Appliance("A04", "Trimmer", "Syska", 5000));*/

            while (true) 
            {
                Console.WriteLine("Enter the choice");
                Console.WriteLine("1.Add appliance details");
                Console.WriteLine("2.Get appliance details");
                Console.WriteLine("3.Find appliance with price range");
                Console.WriteLine("4.Find the highest cost appliance");
                Console.WriteLine("5.Exit");
                int choice = Convert.ToInt32(Console.ReadLine());
                switch(choice)
                {
                    case 1:
                        Console.WriteLine("Enter appliance id");
                        string pid = Console.ReadLine();
                        Console.WriteLine("Enter product name");
                        string pname = Console.ReadLine();
                        Console.WriteLine("Enter product brand");
                        string brand = Console.ReadLine();
                        Console.WriteLine("Enter the price of the product");
                        double price = Convert.ToDouble(Console.ReadLine());
                        Appliance ap = new Appliance(pid, pname, brand, price);
                        if (applianceDetails.Count > 0)
                        {
                            int ckey = applianceDetails.Count;
                            applianceDetails.Add(ckey+1, ap);
                        }
                        else if(applianceDetails.Count == 0)
                            applianceDetails.Add(1, ap);
                        Console.WriteLine("Appliance details added successfully");
                        break; 
                    case 2:
                        Console.WriteLine("Enter the appliance id");
                        string id = Console.ReadLine();
                        Dictionary<string,string> resultid = new Dictionary<string,string>();
                        resultid = pr.GetApplianceDetails(id);
                        if (resultid.Count > 0)
                        {
                            foreach (KeyValuePair<string, string> kvp in resultid)
                                Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
                        }
                        else
                            Console.WriteLine("Appliance id not found");
                        break;
                    case 3:
                        Console.WriteLine("Enter the minimun price range");
                        double minp = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Enter the maximum price range");
                        double maxp = Convert.ToDouble(Console.ReadLine());
                        Dictionary<string, string> resultprice = new Dictionary<string, string>();
                        resultprice = pr.FindApplianceWithPriceRange(minp, maxp);
                        if (resultprice.Count > 0)
                        {
                            foreach (KeyValuePair<string, string> kvp in resultprice)
                                Console.WriteLine("{0} {1}", kvp.Key, kvp.Value);
                        }
                        else
                            Console.WriteLine("No details available within the given range");
                        break;
                     case 4:
                        Dictionary<int, Appliance> highval = new Dictionary<int, Appliance>();
                        highval = pr.FindHighCostAppliance();
                        if (highval.Count == 0)
                            Console.WriteLine("No data found");
                        else
                        {
                            foreach (Appliance app in highval.Values)
                                Console.WriteLine("{0} {1} {2} {3}", app.Id, app.Name, app.Brand, app.Price);
                        }
                        break;
                    case 5:
                        Console.WriteLine("Thank you");
                        return;
                    default:
                        Console.WriteLine("Please enter a valid choice");
                        break;
                }
            }

        }
    }
}