using System;

class CheckThirdDigit
{
    static void Main()
    {
        Console.WriteLine("Please enter a number to check if the third digit is 7");
        int number = int.Parse(Console.ReadLine());
        int thirdDigit = (number / 100) % 10;
        bool checkDigit = (thirdDigit == 7);
        Console.WriteLine("{0} -> {1}", number, checkDigit);
    }
}

