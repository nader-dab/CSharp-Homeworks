using System;

class SumOfThreeNumbers
{
    static void Main()
    {
        Console.WriteLine("Enter a:");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter b:");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter c:");
        int c = int.Parse(Console.ReadLine());
        Console.WriteLine("{0} + {1} + {2} = {3}", a, b, c, a + b + c);
        
    }
}

