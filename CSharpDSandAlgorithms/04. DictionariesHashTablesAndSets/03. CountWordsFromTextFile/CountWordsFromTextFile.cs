namespace _03.CountWordsFromTextFile
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.RegularExpressions;

    public class CountWordsFromTextFile
    {
        public static void Main(string[] args)
        {
            string textFile = File.ReadAllText(@"..\..\words.txt");

            MatchCollection words = Regex.Matches(textFile, @"\b\w+\b");

            Dictionary<string, int> occurances = new Dictionary<string, int>();

            foreach (var word in words)
            {
                string lowerCaseWord = word.ToString().ToLower();

                if (occurances.ContainsKey(lowerCaseWord))
                {
                    occurances[lowerCaseWord]++;
                }
                else
                {
                    occurances.Add(lowerCaseWord, 1);
                }
            }

            var orderedOccurane =
                from entry in occurances
                orderby entry.Value
                select entry;

            foreach (var word in orderedOccurane)
            {
                Console.WriteLine("{0} -> {1}", word.Key, word.Value);
            }
        }
    }
}
