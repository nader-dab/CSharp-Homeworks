using System;
using System.Numerics;

class FibonacciMembers
{
    static void Main()
    {
        Console.Title = "Fibonacci Members";
        BigInteger fibonacciNumber = 0;
        BigInteger prevNumber = 1;
        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine(fibonacciNumber);
            fibonacciNumber = fibonacciNumber + prevNumber;
            prevNumber = fibonacciNumber - prevNumber;
        }
    }
}

