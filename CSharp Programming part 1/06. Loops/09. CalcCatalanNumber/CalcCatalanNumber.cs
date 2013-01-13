using System;
using System.Numerics;

class CalcCatalanNumber
{
    static BigInteger CalcFactorial(int n)
    {
        BigInteger nFactorial = 1;
        for (int i = 1; i <= n; i++)
        {
            nFactorial *= i;
        }
        return nFactorial;
    }

    static void Main()
    {
        int number;
        do
        {
            Console.Write("Please enter n: ");
        } 
        while (!int.TryParse(Console.ReadLine(), out number) || number <= 0);

        BigInteger catalan = CalcFactorial(2 * number) / (CalcFactorial(number + 1) * CalcFactorial(number));
        Console.WriteLine("The catalan number for {0} is: {1}", number, catalan);
    }
}

