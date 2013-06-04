namespace _04.LongestSubsequenceOfEqualNumbers
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class LongestSubsequenceOfEqualNumbers
    {
        public static void Main(string[] args)
        {
            List<int> sequence = new List<int>();

            while (true)
            {
                string line = Console.ReadLine();

                if (line == string.Empty)
                {
                    break;
                }

                int number = int.Parse(line);
                sequence.Add(number);
            }

            SequenceFinder finder = new SequenceFinder();

            List<int> longestEqualSequence = finder.GetEqualNumbersSubsequence(sequence);

            foreach (int number in longestEqualSequence)
            {
                Console.WriteLine(number);
            }
        }
    }
}
