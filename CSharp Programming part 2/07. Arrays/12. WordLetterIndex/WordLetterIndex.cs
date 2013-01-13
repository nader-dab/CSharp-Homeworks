using System;

class WordLetterIndex
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter a word");
        string word = Console.ReadLine();
        char[] letterArray = new char[26];

        for (int i = 0; i < letterArray.GetLength(0); i++)
        {
            letterArray[i] = (char)('A' + i);
        }

        for (int i = 0; i < word.Length; i++)
        {
            bool letterFound = false;
            for (int j = 0; j < letterArray.GetLength(0); j++)
            {
                if (word[i] == letterArray[j] || word[i] == (char)(letterArray[j] + 32))
                {
                    Console.WriteLine("{0} - > {1}[{2}]", word[i], letterArray[j], j);
                    letterFound = true;
                }
            }
            if (letterFound == false)
            {
                Console.WriteLine("{0} - > Not a letter", word[i]);
            }
        }
    }
}

