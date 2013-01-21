using System;
using System.Collections.Generic;

class ShortBinaryRepresentation
{
    static void Main()
    {
        Console.WriteLine("Please enter a 16bit signed integer: ");
        int number = int.Parse(Console.ReadLine());
        List<int> binValue = new List<int>();
        if (number >= 0)
        {
            while (number != 0)
            {
                binValue.Add(number % 2);
                number = number / 2;
            }
            while(binValue.Count % 16 != 0)
            {
                binValue.Add(0);
            }
            binValue.Reverse();
        }
        else
        {
            number = Math.Abs(number) - 1;
            while (number != 0)
            {
                if (number % 2 == 0)
                {
                    binValue.Add(1);
                }
                else
                {
                    binValue.Add(0);
                }
                number = number / 2;
            }
            while (binValue.Count % 16 != 0)
            {
                binValue.Add(1);
            }
            binValue.Reverse();
        }
        Console.Write("The bit value: ");
        foreach (var item in binValue)
        {
            Console.Write(item);
        }
        Console.WriteLine();
    }
}