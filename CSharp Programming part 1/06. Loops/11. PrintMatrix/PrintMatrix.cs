using System;

class PrintMatrix
{
    static void Main()
    {
        int number;
        do
        {
            Console.Write("Please enter a number: ");
        } 
        while (!int.TryParse(Console.ReadLine(), out number) || number <= 0 || number > 20);

        for (int i = 1; i <= number; i++)
        {
            for (int k = i; k < i + number; k++)
            {
                Console.Write("{0, -3}", k);
            }
            Console.WriteLine();
        }
    }
}

