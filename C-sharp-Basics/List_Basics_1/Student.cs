using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace List_Basics_1
{
    public class Student
    {
        public string StudentName { get; set; }
        public string DOB { get; set; }
        public long PhoneNo { get; set; }
        public string City { get; set; }

        public Student() { }

        public Student(string sname, string dob, long phone, string city) 
        { 
            StudentName = sname;
            DOB = dob;
            PhoneNo = phone;
            City = city;
        }

        /*Program prog = new Program();*/

        public List<Student> AddStudentDetails(string name, string dob, long phone, string city)
        {
            Student student = new Student(name,dob,phone,city);
            Program.StudentList.Add(student);
            return Program.StudentList;
        }

        public string GetStudentName(long phone)
        {

        }

        public List<Student> RemoveStudentDetails(long phone)
        {

        }


    }
}
