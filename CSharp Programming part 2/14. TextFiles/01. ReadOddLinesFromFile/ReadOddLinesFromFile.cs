using System;
using System.IO;

public class ReadOddLinesFromFile
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Please enter filename");
            string fileName = Console.ReadLine();
            StreamReader reader = new StreamReader(fileName);
            using (reader)
            {
                string readThroughString = reader.ReadToEnd();
                string[] lines = readThroughString.Split('\n');
                for (int index = 0; index < lines.Length; index++)
                {
                    if (index % 2 == 0)
                    {
                        Console.WriteLine(lines[index]); 
                    }
                }
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
}