using System;
using System.Numerics;

class CalcTrailingZeros
{
    static void Main()
    {
        int n;
        BigInteger nFatorial = 1;
        do
        {
            Console.Write("Please enter a number: ");
        } 
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0);

        for (int i = 1; i <= n; i++)
        {
            nFatorial *= i;
        }
        int trailingZeroes = 0;
        string stringOfNFactorial = Convert.ToString(nFatorial);
        for (int i = stringOfNFactorial.Length - 1; i >= 0; i--)
        {
            if (stringOfNFactorial[i] == '0')
            {
                trailingZeroes++;
            }
            else
            {
                break;
            }
        }
        Console.Write("N = {0} -> N! = ", n);
        for (int i = 0; i < stringOfNFactorial.Length - trailingZeroes; i++)
        {
            Console.Write(stringOfNFactorial[i]);
        }
        Console.ForegroundColor = ConsoleColor.Cyan;
        for (int i = stringOfNFactorial.Length - trailingZeroes; i < stringOfNFactorial.Length; i++)
        {
            Console.Write(stringOfNFactorial[i]);
        }
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(" -> {0}", trailingZeroes);
    }
}
