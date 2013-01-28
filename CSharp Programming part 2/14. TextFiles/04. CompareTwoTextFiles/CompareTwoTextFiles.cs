using System;
using System.IO;
using System.Text;

public class CompareTwoTextFiles
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Please enter location for first file");
            string firstFile = Console.ReadLine();
            string[] readThroughFirstFile = ReadThroughFile(firstFile);

            Console.WriteLine("Please enter location for second file");
            string secondFile = Console.ReadLine();
            string[] readThroughSecondFile = ReadThroughFile(secondFile);

            CompareFiles(readThroughFirstFile, readThroughSecondFile);
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

    private static void CompareFiles(string[] readThroughFirst, string[] readThroughSecond)
    {
        int smallerFile = Math.Min(readThroughFirst.Length, readThroughSecond.Length);
        int sameLines = 0;
        for (int index = 0; index < smallerFile; index++)
        {
            if (readThroughFirst[index] == readThroughSecond[index])
            {
                sameLines++;
            }
        }

        int differentLines = Math.Max(readThroughFirst.Length, readThroughSecond.Length) - sameLines;
        Console.WriteLine("Number of same lines: {0}", sameLines);
        Console.WriteLine("Number of different lines: {0}", differentLines); 
    }

    private static string[] ReadThroughFile(string fileName)
    {
        StreamReader reader = new StreamReader(fileName);
        string[] lines;
        using (reader)
        {
            string readThroughString = reader.ReadToEnd();
            lines = readThroughString.Split('\n');
        }

        return lines;
    }
}