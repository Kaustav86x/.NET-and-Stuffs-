namespace List_Basics_1 
{
    public class Program
    {
        public static List<Student> StudentList { get; set; } = new List<Student>(); // most important line
        public static void Main(string[] args)
        {
            while (true) 
            {
                Console.WriteLine("Choose the option");

                Console.WriteLine("1.Add the student details");
                Console.WriteLine("2.Get student name by phone");
                Console.WriteLine("3.Remove student details");
                Console.WriteLine("4.Exit");

                int option = Convert.ToInt32(Console.ReadLine());

                switch(option)
                {
                    case 1: Console.WriteLine("Enter stduent name");
                            string name = Console.ReadLine();

                        Console.WriteLine("Enter date of birth");
                        string dob = Console.ReadLine();

                        Console.WriteLine("Enter phone number");
                        long phone = Convert.ToInt64(Console.ReadLine());

                        Console.WriteLine("Enter the city");
                        string city = Console.ReadLine();

                        Student student = new Student(name, dob, phone, city);

                        StudentList.Add(student);

                        Console.WriteLine("{0} {1} {2} {3}",name,dob,phone,city);
                        break;

                    case 2: Console.WriteLine("Enter the phone number");
                            long pnum = Convert.ToInt64(Console.ReadLine());
                            
                }
            }
            
        }
    }
}
