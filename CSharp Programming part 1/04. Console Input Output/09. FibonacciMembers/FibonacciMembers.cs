using System;
using System.Numerics;

class FibonacciMembers
{
    static void PrintAllFibonacci()
    {
    int n = 0;
    while(true)
        Console.WriteLine(Fib(n++));
    }
    static int Fib(int n)
    {
        if(n <= 1) return n;
        else return Fib(n - 1) + Fib(n - 2);
    }
    static void Main()
    {
        PrintAllFibonacci();
    }
}

