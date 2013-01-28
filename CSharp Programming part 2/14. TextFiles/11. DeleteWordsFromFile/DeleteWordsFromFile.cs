using System;
using System.IO;
using System.Text.RegularExpressions;

class DeleteWordsFromFile
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Please enter file location.");
            string fileName = Console.ReadLine();
            string word = "test";
            DeleteWord(fileName, word);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The file path is empty.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Cannot find the specified file");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Cannot find the specified file");
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

    private static void DeleteWord(string fileName, string word)
    {
        if (fileName == string.Empty)
        {
            throw new ArgumentNullException();
        }

        StreamReader reader = new StreamReader(fileName);
        string text;
        using (reader)
        {
            text = reader.ReadToEnd();
        }

        string pattern = @"\b" + word + @"\w*\b";
        Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
        string modified = rgx.Replace(text, string.Empty); 
        StreamWriter writer = new StreamWriter(fileName, false);
        using (writer)
        {
            writer.Write(modified);
        }
    }
}