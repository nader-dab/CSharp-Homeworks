using System;
using System.Collections.Generic;

public class ReverseDigitsOfNumber
{
    public static void Main()
    {
        decimal number = 256;
        decimal reversedNumber = ReverseDigits(number);
        Console.WriteLine(reversedNumber);
    }

    public static decimal ReverseDigits(decimal number)
    {
        decimal reversedNumber = 0;
        while (number != 0)
        {
            reversedNumber *= 10;
            reversedNumber += number % 10;
            number = Math.Truncate(number / 10);
        }

        return reversedNumber;
    }
}