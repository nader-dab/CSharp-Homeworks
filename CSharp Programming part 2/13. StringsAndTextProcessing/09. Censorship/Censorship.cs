using System;

class Censorship
{
    static void Main()
    {
        Console.WriteLine("Please enter text:");
        string text = Console.ReadLine();

        string censoredText = CensoreText(text, "PHP", "CLR", "Microsoft");
        Console.WriteLine(censoredText);
    }

    private static string CensoreText(string text, params string[] words)
    {
        for (int wordIndex = 0; wordIndex < words.Length; wordIndex++)
        {
            text = text.Replace(words[wordIndex], new string('*', words[wordIndex].Length));
        }

        return text;
    }
}