namespace InsuranceDetails
{
    public class Program
    {
        public double addPolicy(Insurance ins, int opt)
        {
            if (opt == 1)
            {
                return ins.calculatePremium();
            }
            else if (opt == 2)
            {
                return ins.calculatePremium();
            }
            return 0;
        }

        public static void Main(string[] args)
        {
            int choice;
            int polterms;
            int benprecent;
            int depercent;
            double amnt;
            double result;
            string iname;
            string inum;

            /*Insurance I = new Insurance();*/
            Program p = new Program();
            Console.WriteLine("Insurance Number");
            inum = Console.ReadLine();

            Console.WriteLine("Insurance Name");
            iname = Console.ReadLine();

            Console.WriteLine("Amount Covered");
            amnt = Convert.ToDouble(Console.ReadLine());

            Insurance I = new Insurance(inum, iname, amnt);

            Console.WriteLine("Select\n\n1.Life Insurance\n\n2.Motor Insurance\n");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Policy Terms : ");
                    polterms = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("Benefit Percent : ");
                    benprecent = Convert.ToInt32(Console.ReadLine());

                    Insurance li = new LifeInsurance(inum, iname, amnt, polterms, benprecent);

                    result = p.addPolicy(li, 1);
                    Console.WriteLine("Calculated Premium : {0}", result);
                    break;

                case 2:
                    Console.WriteLine("Depreciation Percent : ");
                    depercent = Convert.ToInt32(Console.ReadLine());

                    Insurance mi = new MotorInsureance(inum, iname, amnt, depercent);

                    result = p.addPolicy(mi, 2);

                    Console.WriteLine("Calculated Premium : {0}", result);
                    break;

                case 3: Console.WriteLine("Invalid Option !!");
            }

        }
    }
}