namespace _02.ExtractOddOccurances
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ExtractOddOccurances
    {
        public static void Main(string[] args)
        {
            string[] wordSequence = new string[] {"C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            Dictionary<string, int> occurances = new Dictionary<string, int>();

            foreach (var word in wordSequence)
            {
                if (occurances.ContainsKey(word))
                {
                    occurances[word]++;
                }
                else
                {
                    occurances.Add(word, 1);
                }
            }

            var oddOccurances =
                from entry in occurances
                where entry.Value % 2 != 0
                select entry.Key;

            Console.WriteLine(string.Join(", ", oddOccurances));
        }
    }
}
