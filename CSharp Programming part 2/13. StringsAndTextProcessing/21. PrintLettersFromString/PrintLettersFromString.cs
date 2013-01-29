using System;
using System.Text.RegularExpressions;

class PrintLettersFromString
{
    static void Main()
    {
        Console.WriteLine("Please enter text:");
        string text = Console.ReadLine();
        CountLetters(text); 
    }

    private static void CountLetters(string text)
    {
        char[] letters = GetLetterns();
        foreach (var letter in letters)
	    {
            string pattern = letter.ToString();
            Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(text);
            if (matches.Count != 0)
            {
                Console.WriteLine("{0}: {1}", letter, matches.Count);
            }
	    }
    }

    private static char[] GetLetterns()
    {
        char[] letters = new char[26];
        letters[0] = 'a';
        for (int index = 1; index < letters.Length; index++)
        {
            letters[index] = (char)(letters[index - 1] + 1);
        }
        return letters;
    }
}