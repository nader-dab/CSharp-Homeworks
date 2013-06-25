using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
namespace _05.Businessmen
{
    class Program
    {
        static void Main(string[] args)
        {
            BigInteger n = int.Parse(Console.ReadLine());
            n = n / 2;
            BigInteger result = FindCatalan(n);
            Console.WriteLine(result);
        }

        private static BigInteger FindCatalan(BigInteger n)
        {
            BigInteger twoTimesN = Factorial(2 * n);
            BigInteger nPlusOne = Factorial(n + 1);
            BigInteger nFactorial = Factorial(n);

            return twoTimesN / (nPlusOne * nFactorial);
        }

        private static BigInteger Factorial(BigInteger number)
        {
            BigInteger result = 1;
            for (BigInteger i = 1; i <= number; i++)
            {
                result *= i;
            }
            return result;
        }
    }
}
