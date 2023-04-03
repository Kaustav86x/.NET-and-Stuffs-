namespace Appointment_Details
{
    public class Program
    {
        public static List<Appointment> AppointmentList { get; set; } = new List<Appointment>();

        public void AddAppointmentDetails(string[] details)
        {
            foreach(string info in details)
            {
                string[] val = info.Split(',');
                Appointment appoint = new Appointment(val[0], val[1], val[2], val[3]);
                AppointmentList.Add(appoint);
            }
        }

        public List<Appointment> ViewBookingDetailsByReason(string reason)
        {
            List<Appointment> app = new List<Appointment>(); 
            foreach(Appointment appointment in AppointmentList) 
            {
                if(appointment.Reason == reason)
                    app.Add(appointment);
            }
            return app;
        }

        public List<Appointment> ViewBookingDetailsByDate(string date)
        {
            List<Appointment> appnt = new List<Appointment>();
            foreach(Appointment app in AppointmentList) 
            {
                if (app.Date == date)
                    appnt.Add(app);
            }
            return appnt;
        }

        public static void Main(string[] args)
        {
            List<Appointment> result1 = new List<Appointment>();
            List<Appointment> result2 = new List<Appointment>();
            int choice;
            Program pr = new Program();
            while (true)
            {
                Console.WriteLine("1.Add Appointment Details");
                Console.WriteLine("2.View Details By Appointment Reason");
                Console.WriteLine("3.View Details By Appointment Dete");
                Console.WriteLine("4.Exit");

                Console.WriteLine("Enter the choice");
                choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter the number of entries");
                        int entires = Convert.ToInt32(Console.ReadLine());
                        string[] str = new string[entires];
                        for (int i = 0; i < str.Length; i++)
                        {
                            str[i] = Console.ReadLine();
                        }
                        pr.AddAppointmentDetails(str);
                        /*if(AppointmentList.Count != 0)
                        {
                            foreach (Appointment app in AppointmentList)
                                Console.WriteLine("{0} {1} {2} {3}", app.PatientName, app.Date, app.Time, app.Reason);
                        }
                        else { Console.WriteLine("No data found !!"); }*/
                            
                        break;
                    case 2:
                        Console.WriteLine("Enter the appointment reason");
                        string reas = Console.ReadLine();
                        result1 = pr.ViewBookingDetailsByReason(reas);
                        if (result1.Count != 0)
                        {
                            foreach (Appointment app in result1)
                                Console.WriteLine("{0}\t{1}\t{2}\t{3}", app.PatientName, app.Date, app.Time, app.Reason);
                        }
                        else
                            Console.WriteLine("No reason found !");
                        break;
                    case 3:
                        Console.WriteLine("Enter the appointment date");
                        string date = Console.ReadLine();
                        result2 = pr.ViewBookingDetailsByDate(date);
                        if (result2.Count != 0)
                        {
                            foreach (Appointment app in result2)
                                Console.WriteLine("{0}\t{1}\t{2}\t{3}", app.PatientName, app.Date, app.Time, app.Reason);
                        }
                        else
                            Console.WriteLine("No date found !");
                        break;
                    case 4: 
                        Console.WriteLine("Thank You.");
                        return;
                }
            }
        }
    }
}