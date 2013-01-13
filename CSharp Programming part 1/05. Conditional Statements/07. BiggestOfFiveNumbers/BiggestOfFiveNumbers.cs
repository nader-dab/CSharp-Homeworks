using System;

class Program
{
    static void Main()
    {
        int[] numbers = new int[5];
        for (int i = 0; i < 5; i++)
        {
            Console.Write("Please enter a number: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out numbers[i]))
                {
                    break;
                }
                Console.Write("Incorrect input. Please enter a proper value: ");
            }
        }
        int greatestNumber = numbers[0];
        for (int i = 0; i < 5; i++)
        {
            if (numbers[i] > greatestNumber)
            {
                greatestNumber = numbers[i];
            }
        }
        Console.WriteLine("The greatest number is: {0}", greatestNumber);
    }
}

