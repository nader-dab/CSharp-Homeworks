using System;
using System.Numerics;

class CalcSumOfNFibonacciMemebers
{
    static void Main()
    {
        string input;
        int n;
        do
        {
            Console.Write("Enter N: ");
            input = Console.ReadLine();
        }
        while (!int.TryParse(input, out n) || n < 0);
        BigInteger fibonacciNumber = 0;
        BigInteger prevNumber = 1;
        BigInteger fibonacciSum = 0;

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(fibonacciNumber);
            fibonacciSum = fibonacciSum + fibonacciNumber;
            fibonacciNumber = fibonacciNumber + prevNumber;
            prevNumber = fibonacciNumber - prevNumber;
        }
        Console.WriteLine("sum = {0}", fibonacciSum);
    }
}

