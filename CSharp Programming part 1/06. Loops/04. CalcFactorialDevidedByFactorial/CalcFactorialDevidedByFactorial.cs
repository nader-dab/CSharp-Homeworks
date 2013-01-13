using System;
using System.Numerics;

class CalcFactorialDevidedByFactorial
{
    static int EnterNumber(char name, int lowerLimit)
    {
        int number;
        do
        {
            Console.Write("Input {0}: ", name);
        } 
        while (!(int.TryParse(Console.ReadLine(), out number)) || (number <= lowerLimit));
        return number;
    }

    static void Main()
    {
        int n = EnterNumber('N', 1); ;
        int k = EnterNumber('K', n);;
        BigInteger nFactorial = 1;
        BigInteger kFactorial = 1;
        BigInteger division;

        for (int i = 1; i <= n; i++)
        {
            nFactorial *= i;
        }

        for (int i = 1; i <= k; i++)
        {
            kFactorial *= i;
        }
        division = nFactorial / kFactorial;
        Console.WriteLine(division);
    }
}

