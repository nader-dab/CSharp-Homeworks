using System;
using System.IO;
using System.Text.RegularExpressions;

public class CountWordsInFile
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Please enter location for words.txt");
            string wordsFile = Console.ReadLine();

            Console.WriteLine("Please enter location for test.txt");
            string testFile = Console.ReadLine();

            string resultFile = "result.txt";

            CountWords(wordsFile, testFile, resultFile);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("File paths must not be empty.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Cannot find the specified files.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Cannot find the specified directories.");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Path is in invalid format.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("The file is either read-only or you do not have the required permission.");
        }
    }

    private static void CountWords(string wordsFile, string testFile, string resultFile)
    {
        if (wordsFile == string.Empty || testFile == string.Empty)
        {
            throw new ArgumentNullException();
        }

        string[] words = GetWords(wordsFile);
        string test = ReadThrough(testFile);

        int[] count = new int[words.Length];
        for (int index = 0; index < words.Length; index++)
        {
            if (Regex.Matches(test, words[index], RegexOptions.IgnoreCase).Count !=  0)
            {
                count[index] = Regex.Matches(test, words[index], RegexOptions.IgnoreCase).Count;
            }
        }

        WriteResults(resultFile, words, count);
    }
  
    private static void WriteResults(string resultFile, string[] words, int[] count)
    {
        StreamWriter writer = new StreamWriter(resultFile);
        using (writer)
        {
            for (int index = 0; index < words.Length; index++)
            {
                writer.WriteLine("{0}: {1}", words[index], count[index]);
            }
        }

        Console.WriteLine("A {0} was created in the following work directory -> {1}", resultFile, Environment.CurrentDirectory);
    }

    private static string ReadThrough(string testFile)
    {
        StreamReader reader = new StreamReader(testFile);
        using (reader)
        {
            string test = reader.ReadToEnd();
            return test;
        }
    }

    private static string[] GetWords(string wordsFile)
    {
        StreamReader reader = new StreamReader(wordsFile);
        using (reader)
        {
            string[] words = reader.ReadToEnd().Split( new char[]{' ', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            return words;
        }
    }
}