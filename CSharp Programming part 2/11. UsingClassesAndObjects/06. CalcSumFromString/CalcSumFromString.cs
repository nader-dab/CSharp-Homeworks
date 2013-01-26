using System;

class CalcSumFromString
{
    static void Main()
    {
        Console.WriteLine("Write a sequence of positive integer values separted by space.");
        string values = Console.ReadLine();
        string[] numbers = values.Split(' ');
        long sum = 0;
        foreach (var item in numbers)
        {
            sum += int.Parse(item);
        }
        Console.WriteLine("string = \"{0}\" -> result = {1}", values, sum);
    }
}