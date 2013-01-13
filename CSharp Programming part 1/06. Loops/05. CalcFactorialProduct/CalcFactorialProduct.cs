using System;
using System.Numerics;
class CalcFactorialProduct
{
    static int EnterNumber(char name, int lowerLimit)
    {
        int number;
        string input;
        do
        {
            Console.Write("Please enter number for {0}: ", name);
            input = Console.ReadLine();
        } 
        while (!int.TryParse(input, out number) || (number <= lowerLimit));
        return number;
    
    }
    static void Main()
    {
        int n = EnterNumber('N', 1); ;
        int k = EnterNumber('K', n);
        BigInteger nFactorial = 1;
        BigInteger kFactorial = 1;
        BigInteger kMinusNFactorial = 1;
        BigInteger product;

        for (int i = 1; i <= n; i++)
        {
            nFactorial *= i;
        }

        for (int i = 1; i <= k; i++)
        {
            kFactorial *= i;
        }
        for (int i = 1; i <= (k - n); i++)
        {
            kMinusNFactorial *= i;
        }

        product = (nFactorial * kFactorial) / kMinusNFactorial;

        Console.WriteLine(product);
    }
}

