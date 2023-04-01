public class Program
{
    public static void Main(string[] args)
    {
        DateTime d1 = DateTime.Now; // current date
        DateTime d2 = new DateTime(2000, 11, 22); // my dob :)
        TimeSpan span = d1 - d2; // subtraction of two dates resulting in a timespan type of variable 
        Console.WriteLine(span.ToString()); // gives a sting of days, hour, minutes etc :)
        Console.WriteLine(span.Days); // 8165 days 
        Console.WriteLine("My age is {0} years !", span.Days/365);
    }
}