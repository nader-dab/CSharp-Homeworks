using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace _04.RecoverMessage
{
    // Not correct
    class Program
    {
        static List<char[]> letterInput = new List<char[]>();
        static HashSet<char> totalDistincLetters = new HashSet<char>();
        static OrderedBag<string> solutions = new OrderedBag<string>();
        static List<HashSet<char>> distinctReceivedMessageLetters = new List<HashSet<char>>();

        static void Main(string[] args)
        {
            int lineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < lineCount; i++)
            {
                char[] receivedLetters = Console.ReadLine().ToCharArray();
                for (int j = 0; j < receivedLetters.Length; j++)
                {
                    if (!totalDistincLetters.Contains(receivedLetters[j]))
                    {
                        totalDistincLetters.Add(receivedLetters[j]);
                    }
                }

                letterInput.Add(receivedLetters);
            }
            char[] result = new char[totalDistincLetters.Count];

            for (int i = 0; i < letterInput[0].Length; i++)
            {
                distinctReceivedMessageLetters.Add(new HashSet<char>());
            }


            for (int i = 0; i < letterInput[0].Length; i++)
            {
                for (int j = 0; j < letterInput.Count; j++)
                {
                    if (!distinctReceivedMessageLetters[i].Contains(letterInput[j][i]))
                    {
                        distinctReceivedMessageLetters[i].Add(letterInput[j][i]);
                    }
                }
            }

            Solve(result, 0);


            foreach (var item in solutions)
            {
                Console.WriteLine(item);
            }

        }
        static int tableIndex = 0;
        private static void Solve(char[] result, int position)
        {
            if (position >= result.Length)
            {
                solutions.Add(string.Join(string.Empty, result));
                return;
            }
            if (tableIndex >= distinctReceivedMessageLetters.Count)
            {
                tableIndex= 0;

            }
            foreach (var letter in distinctReceivedMessageLetters[tableIndex])
            {
                result[position] = letter;
                Solve(result, position+1);
            }
            tableIndex++;
        }


       
        
    }
}
