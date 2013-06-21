using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.SimulateNestedLoops
{
    class SimulateNestedLoops
    {
        static void Main(string[] args)
        {
            int n = 3;
            int[] numbers = new int[n];
            Generate(0, numbers);
        }

        private static void Generate(int position, int[] numbers)
        {
            if (position>= numbers.Length)
            {
                Console.WriteLine(string.Join(string.Empty, numbers));
                return;
            }

            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[position] = i + 1;
                Generate(position + 1, numbers);
            }
        }
    }
}
