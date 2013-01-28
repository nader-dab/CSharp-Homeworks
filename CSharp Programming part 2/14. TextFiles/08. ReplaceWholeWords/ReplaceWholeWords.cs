using System;
using System.IO;
using System.Text.RegularExpressions;

class ReplaceWholeWords
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Please enter file location.");
            string fileName = Console.ReadLine();
            Replace(fileName);

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

    private static void Replace(string fileName)
    {
        StreamReader reader = new StreamReader(fileName);
        using (reader)
        {
            string writeToFile = "result.txt";
            StreamWriter writer = new StreamWriter(writeToFile);
            using (writer)
            {
                string line = reader.ReadLine();
                string pattern = @"\b(start)\b";
                Regex rgx = new Regex(pattern);
                while (line != null)
                {
                    line = rgx.Replace(line, "finish");
                    writer.WriteLine(line);
                    line = reader.ReadLine();
                }

                Console.WriteLine("A {0} was created in the following work directory -> {1}", writeToFile, Environment.CurrentDirectory);
            }

        }
    }
}