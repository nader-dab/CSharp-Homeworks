// Way too many homeworks and no time to implement the full Trie. Here is a practical solution instead :>
namespace _03.FindWords
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text.RegularExpressions;

    public class FindWordsDemo
    {
        const string TextFile = @"..\..\text.txt";
        const string WordsFile = @"..\..\words.txt";

        public static void Main(string[] args)
        {
            string text = File.ReadAllText(TextFile);
            string[] words = File.ReadAllLines(WordsFile);
            Dictionary<string, int> occurances = new Dictionary<string, int>();

            foreach (var word in words)
            {
                Regex rgx = new Regex("\\b" + word + "\\b", RegexOptions.IgnoreCase);
                MatchCollection matches = rgx.Matches(text);
                occurances.Add(word.ToLower(), matches.Count);
            }

            Console.WriteLine(string.Join(Environment.NewLine, occurances));
        }
    }
}
