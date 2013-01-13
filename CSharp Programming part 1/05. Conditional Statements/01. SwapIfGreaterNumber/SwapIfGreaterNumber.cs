using System;

class SwapIfGreaterNumber
{
    static int EnterNumber()
    {
        Console.WriteLine("Plase enter a number: ");
        int number;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out number))
            {
                return number;
            }
            Console.Write("Incorrect Number. Please enter a propper value: ");
        }
    }

    static void Main()
    {

        int firstNumber = EnterNumber();
        int secondNumber = EnterNumber();
        int greaterNumber = firstNumber;

        if (firstNumber > secondNumber)
        {
            firstNumber = secondNumber;
            secondNumber = greaterNumber;
        }

        Console.WriteLine("First number = {0}", firstNumber);
        Console.WriteLine("Second number = {0}", secondNumber);
    }
}

