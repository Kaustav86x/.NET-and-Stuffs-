using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mystic_Beauty_Parlour
{
    public class Customer
    {
        public string CustomerName { get; set; }
        public long MobileNumber { get; set; }
        public string City { get; set; }
        public string Service { get; set; }


        public Customer() { }   
        public Customer(string customerName, long mobileNumber, string city, string service)
        {
            CustomerName = customerName;
            MobileNumber = mobileNumber;
            City = city;
            Service = service;
        }

        public bool AddCustomer(string name, long mobileNo, string city, string service)
        {
            /*Program pr = new Program();*/
            // object being created
            Customer cust = new Customer(name, mobileNo, city, service);
            Program.CustomerQueue.Enqueue(cust);
            if(Program.CustomerQueue.Count > 0)
                return true;
            else
                return false;
        }

        public string GetCustomerNameWithService()
        {
            Customer custname = Program.CustomerQueue.Peek();
            string cname = custname.CustomerName.ToUpper();
            string ser = custname.Service.ToLower();

            return (cname.Trim()+ser.Trim());
        }

        public Queue<Customer> RemoveCustomerDetails(long mobileNo)
        {
            /*Queue<Customer> cstdetails = new Queue<Customer>();*/
            /*Customer cst = new Customer();*/
            foreach(Customer c in Program.CustomerQueue)
            {
                if (c.MobileNumber == mobileNo)
                    /*cst = Program.CustomerQueue.Dequeue();*/
                    /*cstdetails.Enqueue(c);*/
                    /*cstdetails.Enqueue(Program.CustomerQueue.Dequeue());*/
                    Program.CustomerQueue.Dequeue();
            }
            /*cstdetails.Enqueue(cst);*/
            return Program.CustomerQueue;
        }
    }
}
