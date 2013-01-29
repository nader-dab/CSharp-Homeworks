using System;
using System.Collections.Generic;

public class ReverseWordsInSentence
{  
    public static void Main()
    {
        Console.WriteLine("Please enter a sentence:");
        string sentence = Console.ReadLine();
        string[] words = sentence.Split(' ');
        char[] punctuations = { '.', ',', '?', '!' };
        List<PunctuationMarks> locationOfMarks = new List<PunctuationMarks>();
        for (int wordIndex = 0; wordIndex < words.Length; wordIndex++)
        {
            for (int letterIndex = 0; letterIndex < words[wordIndex].Length; letterIndex++)
            {
                for (int checkIndex = 0; checkIndex < punctuations.Length; checkIndex++)
                {
                    if (words[wordIndex][letterIndex] == punctuations[checkIndex])
                    {
                        locationOfMarks.Add(new PunctuationMarks 
                        { 
                            WordPosition = wordIndex, Mark = words[wordIndex][letterIndex] 
                        });

                        words[wordIndex] = words[wordIndex].Remove(letterIndex, 1);
                        break;
                    }
                }
            }
        }

        string[] reversedWords = new string[words.Length];
        for (int index = 0, reversedIndex = words.Length - 1; index < words.Length; index++, reversedIndex--)
        {
            reversedWords[reversedIndex] = words[index];
        }

        for (int index = 0; index < locationOfMarks.Count; index++)
        {
            reversedWords[locationOfMarks[index].WordPosition] += locationOfMarks[index].Mark;
        }

        Console.WriteLine(string.Join(" ", reversedWords));
    }

    public struct PunctuationMarks
    {
        public int WordPosition;
        public char Mark;
    }
}