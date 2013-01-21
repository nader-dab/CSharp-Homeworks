using System;
using System.Text;

class ConvertHexadecimalToBinary
{
    static void Main()
    {
        Console.WriteLine("Please enter hexadecimal value: ");
        string hexNumber = Console.ReadLine();
        StringBuilder sb = new StringBuilder();
        for (int index = hexNumber.Length - 1; index >= 0; index--)
        {
            sb.Insert(0, CheckValue(hexNumber[index]));
        }
        Console.WriteLine("The binary value: {0}", sb.ToString());
    }
    static string CheckValue(char value)
    {
        switch (value)
        {
            case '0': return "0000";
            case '1': return "0001";
            case '2': return "0010";
            case '3': return "0011";
            case '4': return "0100";
            case '5': return "0101";
            case '6': return "0110";
            case '7': return "0111";
            case '8': return "1000";
            case '9': return "1001";
            case 'A': return "1010";
            case 'B': return "1011";
            case 'C': return "1100";
            case 'D': return "1101";
            case 'E': return "1110";
            case 'F': return "1111";
            default: return "0000";
        }
    }
}

