using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04.AllPermutations
{
    class AllPermutations
    {
        private static readonly int n = 2;
        private static readonly int k = 3;
        private static HashSet<int> set = new HashSet<int>();

        static void Main(string[] args)
        {
            int[] numbers = new int[n];
            for (int i = 0; i < k; i++)
            {
                set.Add(i + 1);
            }

            Generate(0, numbers);
        }

        private static void Generate(int position, int[] numbers)
        {
            if (position >= numbers.Length)
            {
                Console.WriteLine(string.Join(string.Empty, numbers));
                return;
            }

            for (int i = 0; i < k; i++)
            {
                if (set.Contains(i + 1))
                {
                    numbers[position] = i + 1;
                    set.Remove(i + 1);
                    Generate(position + 1, numbers);
                    set.Add(i + 1);
                }
            }
        }
    }
}
