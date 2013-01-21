using System;
using System.Collections.Generic;

class ConvertDecimalToBinary
{
    static void Main()
    {
        Console.WriteLine("Please enter decimal value: ");
        int decNumber = int.Parse(Console.ReadLine());
        List<int> binNumber = new List<int>();
        while (decNumber!= 0)
        {
            if (decNumber % 2 == 1)
            {
                binNumber.Add(1);
            }
            else
            {
                binNumber.Add(0);
            }

            decNumber = decNumber / 2;
        }
        binNumber.Reverse();
        Console.Write("Binary form: ");
        foreach (var item in binNumber)
        {
            Console.Write(item);
        }
        Console.WriteLine();
    }
}

