using System;
using System.IO;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class RemoveAllWordsUsingAList
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Please enter location for the text file");
            string firstFile = Console.ReadLine();

            Console.WriteLine("Please enter location for the file containing words to remove");
            string secondFile = Console.ReadLine();
            
            RemoveWords(firstFile, secondFile);

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

    private static void RemoveWords(string firstFile, string secondFile)
    {
        if (firstFile == string.Empty || secondFile == string.Empty)
        {
            throw new ArgumentNullException();   
        }

        string text = ReadThroughFile(firstFile);
        string[] wordsToRemove = GetWords(secondFile);
        foreach (var word in wordsToRemove)
        {
            text = Regex.Replace(text, word, string.Empty, RegexOptions.IgnoreCase);
        }

        StreamWriter writer = new StreamWriter(firstFile, false);
        using (writer)
        {
            writer.Write(text);
        }
    }

    private static string[] GetWords(string secondFile)
    {
        StreamReader reader = new StreamReader(secondFile);
        using (reader)
        {
            string[] text = reader.ReadToEnd().Split(new char[]{' ', '\n', '\r'}, StringSplitOptions.RemoveEmptyEntries);
            return text;
        }
    }

    private static string ReadThroughFile(string firstFile)
    {
        StreamReader reader = new StreamReader(firstFile);
        using (reader)
        {
            string text = reader.ReadToEnd();
            return text;
        }
    }
}
