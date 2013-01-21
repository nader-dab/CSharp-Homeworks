using System;
using System.Text;

class ConvertBinaryToHexadecimal
{
    static void Main()
    {
        Console.WriteLine("Please enter binary value: ");
        string binNumber = Console.ReadLine();
        if (binNumber.Length % 4 != 0)
        {
            string zeroes = new string('0', 4 - binNumber.Length % 4);
            binNumber = binNumber.Insert(0, zeroes);
        }
        StringBuilder sb = new StringBuilder();
        for (int index = binNumber.Length; index >= 4 - 1 ; index = index - 4)
        {
            sb.Insert(0, CheckValue(binNumber.Substring(index - 4, 4)));
        }
        Console.WriteLine("The binary value: {0}", sb.ToString());

    }
    static char CheckValue(string value)
    {
        switch (value)
        {
            case "0000": return '0';
            case "0001": return '1';
            case "0010": return '2';
            case "0011": return '3';
            case "0100": return '4';
            case "0101": return '5';
            case "0110": return '6';
            case "0111": return '7';
            case "1000": return '8';
            case "1001": return '9';
            case "1010": return 'A';
            case "1011": return 'B';
            case "1100": return 'C';
            case "1101": return 'D';
            case "1110": return 'E';
            case "1111": return 'F';
            default: return '0';
        }
    
    }
}

