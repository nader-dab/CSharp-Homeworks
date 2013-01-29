using System;
using System.Globalization;

class CalcNumberOfDaysBetweenDates
{
    static void Main()
    {
        Console.Write("Enter the first date: "); //27.02.2006
        string input1 = Console.ReadLine();
        DateTime firstDate = DateTime.Parse(input1);
        Console.Write("Enter the second date: "); //3.03.2006
        string input2 = Console.ReadLine();
        DateTime secondDate = DateTime.Parse(input2);
        int daysBetween = (secondDate - firstDate).Days;
        Console.WriteLine("Distance: {0} days", daysBetween);
    }
}