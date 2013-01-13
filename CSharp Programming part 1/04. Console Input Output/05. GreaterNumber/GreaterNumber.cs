using System;

class GreaterNumber
{
    static void Main()
    {
        Console.Title = "Greater Number";
        int firstNumber;
        int secondNumber;
        Console.Write("Enter the first number: ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out firstNumber))
            {
                break;
            }
            Console.Write("Incorrect Input. Please enter a propper value: ");
        }
        Console.Write("Enter the second number: ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out secondNumber))
            {
                break;
            }
            Console.Write("Incorrect Input. Please enter a propper value: ");
        }
        int greaterNumber = Math.Max(firstNumber, secondNumber);
        if (firstNumber != secondNumber)
        {
            Console.WriteLine("{0} is the greater number.", greaterNumber);
        }
        else
        {
            Console.WriteLine("The numbers are equal.");
        }
    }
}

