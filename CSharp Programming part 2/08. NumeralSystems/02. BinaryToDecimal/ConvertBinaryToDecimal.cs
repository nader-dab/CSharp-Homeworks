using System;

class BinaryToDecimal
{
    static void Main()
    {
        Console.WriteLine("Please enter binary value: ");
        string bitNumber = Console.ReadLine();
        int decNumber = 0;

        for (int index = bitNumber.Length - 1; index >= 0; index--)
        {
            if (bitNumber[index] == '1')
            {
                decNumber += (int)Math.Pow(2, bitNumber.Length - 1 - index);
            }
        }
        Console.WriteLine("The decimal value is {0}", decNumber);
    }
}

