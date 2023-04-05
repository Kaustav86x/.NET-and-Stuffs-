using Vitality_Health;
public class Program
{
    public static List<Vaccine> VaccineList { get; set; } = new List<Vaccine>(); // most important line
    /*Vaccine vc = new Vaccine();*/

    public void AddVaccineDetails(string[] vaccineDetails)
    {
        foreach(string vac in vaccineDetails)
        {
            string[] val = vac.Split(',');
            Vaccine vc = new Vaccine(val[0], val[1], val[2], val[3], val[4]) ;
            VaccineList.Add(vc);
        }
    }
    public List<Vaccine> ViewBookingDetailsByDoseNumber(string doseNumber)
    {
        List<Vaccine> list = new List<Vaccine>(); // temporary list
        foreach(Vaccine vc in VaccineList)
        {
            if (vc.DoseNumber.Equals(doseNumber))
                list.Add(vc);
        }
        return list;
    }
    public List<Vaccine> ViewBookingDetailsByVaccineType(string vaccineType)
    {
        List<Vaccine> list = new List<Vaccine>();
        foreach(Vaccine vac in VaccineList)
        {
            if (vac.VaccineType.Equals(vaccineType))
                list.Add(vac);
        }
        return list;
    }
    public static void Main(string[] args)
    {
        Program pr = new Program();
        /*Console.WriteLine("Hello, World!");*/
        Console.WriteLine("1.Add Vaccine Details");
        Console.WriteLine("2.View Details by Dose Number");
        Console.WriteLine("3.View Details By Vacciine Type");
        Console.WriteLine("4.Exit");
        while(true) 
        {
            Console.WriteLine("Enter the choice");
            int choice = Convert.ToInt32(Console.ReadLine());
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
                    pr.AddVaccineDetails(entries);
                    break;
                case 2:
                    Console.WriteLine("Enter the dose number");
                    string dnum = Console.ReadLine();
                    List<Vaccine> result1 = new List<Vaccine>();
                    result1 = pr.ViewBookingDetailsByDoseNumber(dnum);
                    if(result1.Count > 0)
                    {
                        foreach(Vaccine vaccine in result1) 
                        {
                            Console.WriteLine("{0} {1} {2} {3} {4} ", vaccine.BookingId, vaccine.Name, vaccine.VaccineType, vaccine.DoseNumber, vaccine.BookingDate);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Dose number not found");
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter the vaccine type");
                    string vtype = Console.ReadLine();
                    List<Vaccine> result2 = new List<Vaccine>();
                    result2 = pr.ViewBookingDetailsByVaccineType(vtype);
                    if(result2.Count > 0)
                    {
                        foreach (Vaccine vaccin in VaccineList)
                        {
                            Console.WriteLine("{0} {1} {2} {3} {4}", vaccin.BookingId, vaccin.Name, vaccin.VaccineType, vaccin.DoseNumber, vaccin.BookingDate);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Vaccine type not found");
                    }
                    break;
                case 4:
                    Console.WriteLine("Thank you!");
                    return;
            }
        }
    }
}