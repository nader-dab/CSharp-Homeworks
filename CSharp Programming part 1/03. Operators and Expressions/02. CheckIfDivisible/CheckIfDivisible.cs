using System;

class CheckIfDivisible
{
    static void Main()
    {
        Console.WriteLine("please enter a number");
        int number = int.Parse(Console.ReadLine());
        Console.WriteLine( ((number % 5 == 0) && (number % 7 == 0))?
            "The number you've entered is divisible by 5 and 7":
            "The number you've entered is NOT divisible by 5 and 7");
    }
}
