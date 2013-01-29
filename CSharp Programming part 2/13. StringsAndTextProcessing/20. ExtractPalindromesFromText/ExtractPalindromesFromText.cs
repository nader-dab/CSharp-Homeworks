using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class ExtractPalindromesFromText
{
    public static void Main()
    {
        Console.WriteLine("Please enter text:");
        string text = Console.ReadLine();
        ExtractPaindromes(text);
    }

    private static void ExtractPaindromes(string text)
    {
        Regex rgx = new Regex(@"\b\w+\b", RegexOptions.IgnoreCase);
        MatchCollection matches = rgx.Matches(text);
        foreach (var match in matches)
        {
            if (CheckIfSimetric(match.ToString()))
            {
                Console.WriteLine(match.ToString());
            }
        }
    }

    private static bool CheckIfSimetric(string word)
    {
        bool symentrical = true;
        for (int start = 0, end = word.Length - 1; start < word.Length / 2; start++, end--)
        {
            if (char.ToLower(word[start]) != char.ToLower(word[end]))
            {
                symentrical = false;
            }
        }

        return symentrical;
    }
}