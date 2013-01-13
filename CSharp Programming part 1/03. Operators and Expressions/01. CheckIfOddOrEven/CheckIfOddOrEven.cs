using System;

class CheckIfOddOrEven
{
    static void Main()
    {
        Console.WriteLine("Plase enter a number");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine( (number % 2 == 0)?
            "The number you've entered is even":
            "The number you've entered is odd");
    }
}

