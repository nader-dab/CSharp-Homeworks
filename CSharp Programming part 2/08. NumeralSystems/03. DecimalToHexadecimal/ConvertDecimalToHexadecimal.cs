using System;
using System.Collections.Generic;

public class ConvertDecimalToHexadecimal
{
    public static void Main()
    {
        Console.WriteLine("Please enter decimal value: ");
        int decNumber = int.Parse(Console.ReadLine());
        List<char> hexNumber = new List<char>();
        while (decNumber != 0)
        {
            int checkValue = decNumber % 16;
            hexNumber.Add(HexValue(checkValue));
            decNumber = decNumber / 16;
        }

        hexNumber.Reverse();
        Console.WriteLine("The hexadecimal value: ");
        foreach (var item in hexNumber)
        {
            Console.Write(item);
        }

        Console.WriteLine();
    }

    public static char HexValue(int value)
    {
        switch (value)
        {
            case 10: return 'A';
            case 11: return 'B';
            case 12: return 'C';
            case 13: return 'D';
            case 14: return 'E';
            case 15: return 'F';
            default: return (char)(value + 48); 
        }
    }
}