using System;

class Program
{
    static void Main()
    {
        Console.Write("Please enter a number: ");
        int number = int.Parse(Console.ReadLine());
        int lastDigit = number % 10;
        string word = DigitToWord(lastDigit);
        Console.WriteLine("The last digit is {0}.", word);
    }

    static string DigitToWord(int digit)
    {
        string[] numbers = {
                                "zero", 
                                "one", 
                                "two", 
                                "three", 
                                "four", 
                                "five", 
                                "six", 
                                "seven", 
                                "eight", 
                                "nine" 
                           };
        return numbers[digit];
    }
}

