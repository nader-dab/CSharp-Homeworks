using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

class ExtractTextWithoutTags
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Please enter file location.");
            string fileName = Console.ReadLine();
            List<string> textWithoutTags = new List<string>();
            ExtractText(textWithoutTags, fileName);
            foreach (var item in textWithoutTags)
            {
                Console.WriteLine(item);
            }
            
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

    private static void ExtractText(List<string> textWithoutTags, string fileName)
    {
        StreamReader reader = new StreamReader(fileName);
        using (reader)
        {
            string text = reader.ReadToEnd();
            string pattern = @"[\w|\s]*(?=</)";
            Regex rgx = new Regex(pattern);
            MatchCollection matches = rgx.Matches(text);
            foreach (var item in matches)
            {
                if (item.ToString()!= string.Empty)
                {
                    textWithoutTags.Add(item.ToString().Trim(' '));
                }
            }
        }
    }
}