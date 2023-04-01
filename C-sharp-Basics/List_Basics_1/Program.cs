namespace List_Basics_1 
{
    public class Program
    {
        public static List<Student> StudentList { get; set; } = new List<Student>(); // most important line
        public static void Main(string[] args)
        {
            Program prog = new Program();
            Student st = new Student();
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

                        st.AddStudentDetails(name,dob,phone,city);

                        break;

                    case 2: Console.WriteLine("Enter the phone number");
                            long pnum = Convert.ToInt64(Console.ReadLine());

                            string sname = st.GetStudentName(pnum);
                            Console.WriteLine("{0}", sname);
                            break;
                    case 3: Console.WriteLine("Enter the phone number");
                            pnum = Convert.ToInt64(Console.ReadLine());
                            
                            List<Student> list = new List<Student>();
                            list = st.RemoveStudentDetails(pnum);
                            foreach (Student student in list)
                            {
                                Console.WriteLine("{0} {1} {2} {3}",student.StudentName, student.DOB, student.PhoneNo, student.City);
                            }
                            break;
                    case 4: return ;
                }
            }
            
        }
    }
}
