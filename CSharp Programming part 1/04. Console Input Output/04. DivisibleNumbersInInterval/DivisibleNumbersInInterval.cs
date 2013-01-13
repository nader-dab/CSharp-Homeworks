using System;

class DivisibleNumbersInInterval
{
    static void Main()
    {
        int firstNumber;
        int secondNumber;
        Console.WriteLine("Enter first number: ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out firstNumber))
            {
                break;
            }
            Console.Write("Incorrect Input. Please enter a propper value: ");
        }
        Console.WriteLine("Enter second number larger than {0}: ", firstNumber);
        while (true)
        {
            if ((int.TryParse(Console.ReadLine(), out secondNumber)) && (secondNumber > firstNumber))
            {
                break;
            }
            Console.Write("Incorrect Input. Please enter a propper value: ");
        }
       
        int divisibleNumbers = 0;
        for (int i = firstNumber; i <= secondNumber; i++)
        {
            if (i % 5 == 0)
            {
                divisibleNumbers++;
            }
        }
        Console.WriteLine("p({0}, {1}) = {2}", firstNumber, secondNumber, divisibleNumbers);
    }
}
