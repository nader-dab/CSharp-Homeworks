using System;
using System.IO;
using System.Text;

public class ConcatTwoFiles
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Please enter location for first file");
            string firstFile = Console.ReadLine();
            string readThroughFirstFile = ReadThroughFile(firstFile);

            Console.WriteLine("Please enter location for second file");
            string secondFile = Console.ReadLine();
            string readThroughSecondFile = ReadThroughFile(secondFile);

            CreateConcatFile(readThroughFirstFile, readThroughSecondFile); 
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

    private static void CreateConcatFile(params string[] readThrough)
    {
        string writeToFile = "concatFile.txt";
        StreamWriter writer = new StreamWriter(writeToFile);
        using (writer)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in readThrough)
            {
                sb.Append(item);
                sb.Append('\n');
            }

            writer.Write(sb.ToString());
            Console.WriteLine("A {0} was created in the following work directory -> {1}", writeToFile, Environment.CurrentDirectory);
        }
    }

    private static string ReadThroughFile(string filename)
    {
        StreamReader reader = new StreamReader(filename);
        string readThroughFile ;
        using (reader)
        {
            readThroughFile = reader.ReadToEnd();
        }

        return readThroughFile;
    }
}