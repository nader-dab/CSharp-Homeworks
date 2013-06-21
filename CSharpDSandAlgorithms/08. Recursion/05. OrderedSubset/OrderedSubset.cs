using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05.OrderedSubset
{
    class OrderedSubset
    {
        private static readonly int k = 2;
        private static string[] words = new string[] { "hi", "a", "b" };

        static void Main(string[] args)
        {
            string[] result = new string[k];
            Generate(0, result);
        }

        private static void Generate(int position, string[] result)
        {
            if (position >= result.Length)
            {
                Console.WriteLine(string.Join(" ", result));
                return;
            }

            for (int i = 0; i < words.Length; i++)
            {
                result[position] = words[i];
                Generate(position + 1, result);
            }
        }
    }
}
