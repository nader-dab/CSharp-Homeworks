using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Pease enter year");
        short year = short.Parse(Console.ReadLine());
        if (DateTime.IsLeapYear(year))
	    {
            Console.WriteLine("{0} is a leap year", year);
	    }
        else
        {
            Console.WriteLine("{0} is not a leap year", year);
        }
    }
}