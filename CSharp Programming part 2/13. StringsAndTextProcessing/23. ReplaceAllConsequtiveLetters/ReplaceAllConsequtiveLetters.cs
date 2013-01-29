using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ReplaceAllConsequtiveLetters
{
    static void Main()
    {
        Console.WriteLine("Please enter text:");
        string text = Console.ReadLine();
        List<char> letters = new List<char>();
        if (text.Length != 0)
        {
            letters.Add(text[0]);
        } 

        foreach (var letter in text)
        {
            if (letters[letters.Count - 1] != letter )
	        {
                letters.Add(letter);
	        }
        }

        Console.WriteLine(string.Join(string.Empty, letters));
    }
}
