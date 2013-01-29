using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ListAllWordsFromText
{
    public static void Main()
    {
        Console.WriteLine("Please enter text:");
        string text = Console.ReadLine();
        FindUniquetWords(text); 
    }

    private static void FindUniquetWords(string text)
    {
        List<string> wordsFromText = new List<string>();
        string pattern = @"\b\w+\b";
        Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
        MatchCollection matches = rgx.Matches(text);
        foreach (var match in matches)
        {
            if (!wordsFromText.Contains(match.ToString().ToLowerInvariant()))
            {
                wordsFromText.Add(match.ToString().ToLowerInvariant());
            }
        }

        CountWords(text, wordsFromText);
    }
    private static void CountWords(string text, List<string> wordsFromText)
    {
        foreach (var word in wordsFromText)
        {
            string pattern = "\\b" + word + "\\b";
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(text);
            Console.WriteLine("Word: {0, -20} Count: {1, 2}", word, matches.Count);
        }
    }
}