using System;

class PrintNumbersOneToN
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
            Console.WriteLine(i);
        }
    }
}

