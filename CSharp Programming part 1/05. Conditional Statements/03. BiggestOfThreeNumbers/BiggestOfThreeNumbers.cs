using System;

class BiggestOfThreeNumbers
{
    static int EnterNumber()
    {
        Console.Write("Please enter a number: ");
        while (true)
        {
            int number;
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
        int thirdNumber = EnterNumber();
        int biggestNumber = firstNumber;
        if (firstNumber <= secondNumber)
        {
            if (secondNumber<= thirdNumber)
            {
                biggestNumber = thirdNumber;
            }
            else
            {
                biggestNumber = secondNumber;
            }
        }
        else
        {
            if (thirdNumber > firstNumber)
            {
                biggestNumber = thirdNumber;
            }
        }
        Console.WriteLine("The biggest number is: {0}", biggestNumber);
    }
}

