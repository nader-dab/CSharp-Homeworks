using System;
using System.Collections.Generic;
using System.IO;

class DeleteOddLines
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Please enter fil location.");
            string fileName = Console.ReadLine();
            List<string> evenLines = new List<string>();
            evenLines = ReadEvenLines(fileName);
            ReplaceFile(evenLines, fileName);
            
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

    private static void ReplaceFile(List<string> evenLines, string fileName)
    {
        StreamWriter writer = new StreamWriter(fileName, false);
        using (writer)
        {
            foreach (var item in evenLines)
            {
                writer.WriteLine(item);
            }
        }
    }

    private static List<string> ReadEvenLines(string fileName)
    {
        List<string> evenLines = new List<string>();
        StreamReader reader = new StreamReader(fileName);
        using (reader)
        {
            int index = 0;
            for (string line = reader.ReadLine(); line != null; line = reader.ReadLine())
            {
                if (index % 2 == 1)
                {
                    evenLines.Add(line);
                }

                index++;
            }
        }

        return evenLines;
    }
}