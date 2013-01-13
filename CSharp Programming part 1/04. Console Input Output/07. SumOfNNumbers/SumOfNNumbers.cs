using System;

class SumOfNNumbers
{
    static void Main()
    {
        Console.Title = "Sum of N numbers.";
        Console.Write("Please enter total number of values to be calculated: ");
        int n;
        int enteredNumber;
        int sum = 0;
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out n))
            {
                break;
            }
            Console.Write("Incorrect Input. Please enter a propper value: ");
        }
        for (int i = 0; i < n; i++)
        {
            Console.Write("Please enter a number: ");
            while (true)
            {
                if (int.TryParse(Console.ReadLine(), out enteredNumber))
                {
                    break;
                }
                Console.Write("Incorrect Input. Please enter a propper value: ");
            }
            sum = sum + enteredNumber;
        }
        Console.WriteLine();
        Console.WriteLine("The sum of all entered numbers is:");
        Console.WriteLine(sum);
    }
}

