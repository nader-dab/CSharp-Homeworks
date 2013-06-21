using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06.AllSubsetsOfKStrings
{
    class AllSubsetsOfKStrings
    {
        private static readonly int k = 2;
        private static string[] words = new string[] { "test", "rock", "fun" };

        static void Main(string[] args)
        {
            string[] result = new string[k];
            Generate(0, result, 0);
        }

        private static void Generate(int position, string[] result, int currentWord)
        {
            if (position >= result.Length)
            {
                Console.WriteLine(string.Join(" ", result));
                return;
            }

            for (int i = currentWord; i < words.Length; i++)
            {
                result[position] = words[i];
                currentWord++;
                Generate(position + 1, result, currentWord);
            }
        }
    }
}
