using System.Collections;

class Program
{
    public static void Main(string[] args)
    {
        // Console.WriteLine("Hello, World!");
        // generic type (type mentioned)
        List<int> list = new List<int>();
        list.Add(1);
        list.Add(2);
        list.Add(3);
        list.Add(4);
        Console.WriteLine(list.Count);

        // non-generic type (type need not to mention/ can't mention)
        ArrayList list2 = new ArrayList();
        list2.Add(1);
        list2.Add("kaustav");
        list2.Add(3.67);
        list2.Add('a');
        // Console.WriteLine(list2.Count);
        // var means in general variable (not specifying any data type)
        foreach(var i in list2)
            Console.WriteLine(i);
        list2.Remove('a'); // removes from the last part of kror
        // Console.WriteLine(list2);
        foreach(var i in list2)
            Console.WriteLine(i);

        Console.ReadKey();
    }
}