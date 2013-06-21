using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.CombinationsWithDuplicates
{
    class CombinationsWithDuplicates
    {
        private static readonly int n = 2;
        private static readonly int k = 4;

        static void Main(string[] args)
        {
            int[] numbers = new int[n];
            Generate(0, numbers, 0);
        }

        private static void Generate(int position, int[] numbers, int currentNumber)
        {
            if (position >= numbers.Length)
            {
                Console.WriteLine(string.Join(string.Empty, numbers));
                return;
            }

            for (int i = currentNumber; i < k; i++)
            {
                numbers[position] = i + 1;
                Generate(position + 1, numbers, currentNumber);
                currentNumber++;
            }
        }
    }
}
