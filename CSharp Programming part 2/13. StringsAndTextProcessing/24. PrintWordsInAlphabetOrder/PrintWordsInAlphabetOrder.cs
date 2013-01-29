using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Linq;

class PrintWordsInAlphabetOrder
{
    static void Main()
    {
        Console.WriteLine("Please enter text:");
        string text = Console.ReadLine();
        PrintInAlpbetOrder(text);
    }

    private static void PrintInAlpbetOrder(string text)
    {
        List<string> words = GetWords(text);
        words = words.OrderBy((x) => char.ToLower(x[0])).ToList();
        Console.WriteLine(string.Join("\n", words));
    }

    private static List<string> GetWords(string text)
    {
        List<string> words = new List<string>();
        string pattern = @"\b\w+\b";
        Regex rgx = new Regex(pattern);
        MatchCollection matches = rgx.Matches(text);
        foreach (var match in matches)
        {
            words.Add(match.ToString());
        }

        return words;
    }
}