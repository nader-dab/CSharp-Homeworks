using System;

class NumbersNotDivisibleByOneAndSeven
{
    static void Main()
    {
        int n;
        string input;
        do
        {
            Console.WriteLine("Please enter a number: ");
            input = Console.ReadLine();
        }
        while (!int.TryParse(input, out n) || (n < 0));

        for (int i = 1; i <= n; i++)
        {
            if (!((i % 3 == 0) || (i % 7 == 0)))
            {
                Console.WriteLine(i);
            }
        }
    }
}

