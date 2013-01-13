using System;

class CalcTrapezoidArea
{
    static void Main()
    {
        Console.WriteLine("Please enter side a");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter side b");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter side height");
        int h = int.Parse(Console.ReadLine());
        float area = ((a + b) * h) / 2f;
        Console.WriteLine("The area of the prapezoid is ({0} + {1}) x {2} / 2 = {3}", a, b, h, area);
    }
}

