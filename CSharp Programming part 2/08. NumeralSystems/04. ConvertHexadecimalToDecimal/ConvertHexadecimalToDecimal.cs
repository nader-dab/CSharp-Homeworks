using System;

class ConvertHexadecimalToDecimal
{
    static void Main()
    {
        Console.WriteLine("Please enter hexadecimal value: ");
        string hexNumber = Console.ReadLine();
        int decNumber = 0;
        for (int index = hexNumber.Length - 1; index >= 0; index--)
        {
            int checkValue = DecValue(hexNumber[index]);
            decNumber += checkValue * (int)Math.Pow(16, hexNumber.Length - 1 - index);
        }
        Console.WriteLine("The decimal value: {0}", decNumber);
    }
    static int DecValue(char value)
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
}

