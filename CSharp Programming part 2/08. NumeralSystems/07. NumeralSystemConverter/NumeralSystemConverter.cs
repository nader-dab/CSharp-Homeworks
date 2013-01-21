using System;
using System.Collections.Generic;

public class NumeralSystemConverter
{
    public static void Main()
    {
        Console.WriteLine("Please enter value you wish to convert");
        string sBasedValue = Console.ReadLine();
        Console.WriteLine("Please enter the values base: ");
        int sBase = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter the base you wish to convert to");
        int dBase = int.Parse(Console.ReadLine());
        int decimalValue = 0;
        for (int index = sBasedValue.Length - 1; index >= 0; index--)
        {
            decimalValue += CheckValue(sBasedValue[index]) * (int)Math.Pow(sBase, sBasedValue.Length - 1 - index);
        }

        List<char> dBasedValue = new List<char>();
        while (decimalValue != 0)
        {
            int remainder = decimalValue % dBase;
            char symbol = GetValue(remainder);
            dBasedValue.Add(symbol);
            decimalValue = decimalValue / dBase;
        }

        dBasedValue.Reverse();
        Console.WriteLine("The new value is: ");
        foreach (var item in dBasedValue)
        {
            Console.Write(item);
        }

        Console.WriteLine();
    }

    public static int CheckValue(char value)
    {
        switch (value)
        {
            case 'A': return 10;
            case 'B': return 11;
            case 'C': return 12;
            case 'D': return 13;
            case 'E': return 14;
            case 'F': return 15;
            default: return (int)(value - 48);
        }
    }

    public static char GetValue(int value)
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