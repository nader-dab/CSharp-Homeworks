using System;
using System.Collections.Generic;

class ExtractSentenceFromText
{
    static void Main()
    {
        Console.WriteLine("Please enter text:");
        string text = Console.ReadLine();
        Console.WriteLine("Please enter a word to extract:");
        string word = Console.ReadLine().ToLower();
        ExtractSentences(text, word);
    }
  
    private static void ExtractSentences(string text, string word)
    {
        List<int> position = new List<int>();
        string[] originalSentences = text.Split('.');
        string[] sentences = text.Split('.');
        for (int sentenceIndex = 0; sentenceIndex < sentences.Length; sentenceIndex++)
        {
            sentences[sentenceIndex] = sentences[sentenceIndex].ToLower();
            int index = -1;
            while (true)
            {
                index = sentences[sentenceIndex].IndexOf(word, index + 1);
                if (index != -1)
                {
                    if (index + word.Length < sentences[sentenceIndex].Length && !char.IsLetter((char)sentences[sentenceIndex][index + word.Length]) || index + word.Length == sentences[sentenceIndex].Length)
                    {
                        if (index > 0 && !char.IsLetter((char)sentences[sentenceIndex][index - 1]) || index == 0)
                        {
                            position.Add(sentenceIndex);
                        }
                    }
                }

                if (index == -1)
                {
                    break;
                }
            }
        }

        foreach (var item in position)
        {
            Console.WriteLine(originalSentences[item].TrimStart(' ') + ".");
        }
    }
}