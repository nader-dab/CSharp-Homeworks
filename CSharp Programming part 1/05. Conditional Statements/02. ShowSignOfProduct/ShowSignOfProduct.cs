using System;

class ShowSignOfProduct
{
    static int EnterNumber()
    {
        Console.Write("Please enter a number: ");
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
        int thirdNumber = EnterNumber();
        int negativeNumbers = 0;

        if (firstNumber == 0 || secondNumber == 0 || thirdNumber == 0)
        {
            Console.WriteLine("The product is 0");
        }
        else 
        {
            if (firstNumber < 0)
            {
                negativeNumbers++;
            }
            if (secondNumber > 0)
            {
                negativeNumbers++;
            }
            if (thirdNumber > 0)
            {
               negativeNumbers++;
            }
            if (negativeNumbers % 2 == 0)
            {
                Console.WriteLine("The product sign is: +");
            }
            else
            {
                Console.WriteLine("The product sign is: -");
            }
        }
    }
}

