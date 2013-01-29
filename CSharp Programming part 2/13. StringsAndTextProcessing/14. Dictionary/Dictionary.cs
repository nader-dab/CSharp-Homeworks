using System;
using System.Collections.Generic;

public class Dictionary
{
    public static void Main()
    {
        List<Definition> dictionary = new List<Definition>();
        AddTermsToDictionary(dictionary, ".NET", "platform for applications from Microsoft");
        AddTermsToDictionary(dictionary, "CLR", "managed execution environment for .NET");
        AddTermsToDictionary(dictionary, "namespace", "hierarchical organization of classes");
        Console.WriteLine("Please enter a word:");
        string search = Console.ReadLine();
        SearchDictionary(dictionary, search);
    }
  
    private static void SearchDictionary(List<Definition> dictionary, string search)
    {
        int location = -1;
        for (int index = 0; index < dictionary.Count; index++)
        {
            if (dictionary[index].Word == search)
            {
                location = index;
            }
        }

        if (location < 0)
        {
            Console.WriteLine("This word is not in the dictionary");
        }
        else
        {
            Console.WriteLine("{0} - {1}", dictionary[location].Word, dictionary[location].Explanation);
        }
    }

    private static void AddTermsToDictionary(List<Definition> dictionary, string wordTerm, string wordExplanation)
    {
        dictionary.Add(new Definition
        {
            Word = wordTerm,
            Explanation = wordExplanation
        });
    }

    public struct Definition
    {
        public string Word;
        public string Explanation;
    }
}
