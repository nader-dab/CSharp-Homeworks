using System;
using System.IO;
using System.Text;

class ReplaceWordsInFile
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Please enter file location.");
            string fileName = Console.ReadLine();
            string find = "start";
            string replace = "finish";
            Replace(fileName, find, replace);

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

    private static void Replace(string fileName, string find, string replace)
    {
        StreamReader reader = new StreamReader(fileName);
        using (reader)
        {
            string writeToFile = "result.txt";
            StreamWriter writer = new StreamWriter(writeToFile);
            using (writer)
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    line = line.Replace(find, replace);
                    writer.WriteLine(line);
                    line = reader.ReadLine();
                }

                Console.WriteLine("A {0} was created in the following work directory -> {1}", writeToFile, Environment.CurrentDirectory);
            }

        }
    }
}