using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _11.AllPermutationsWithRepetitions
{
    class AllPermutationsWithRepetitions
    {
        static void Main(string[] args)
        {
            int[] initialSet = new int[] { 1, 3, 5, 5 };

            for (int i = 0; i < initialSet.Length; i++)
            {
                for (int j = 0; j < initialSet.Length - 1; j++)
                {
                    Console.WriteLine(string.Join(", ", initialSet));
                    int swap = initialSet[j];
                    initialSet[j] = initialSet[j + 1];
                    initialSet[j + 1] = swap;
                }
            }
        }
    }
}
