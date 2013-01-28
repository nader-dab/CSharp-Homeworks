using System;
using System.IO;
using System.Text;

class InsertRowLines
{
    public static void Main()
    {
        try
        {
            Console.WriteLine("Please enter file location.");
            string fileName = Console.ReadLine();
            string[] textLines = ReadThroughFile(fileName);
            textLines = InsertRowNumebrs(textLines);
            CreateFile(textLines); 
            
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

    private static void CreateFile(params string[] readThrough)
    {
        string writeToFile = "modifiedFile.txt";
        StreamWriter writer = new StreamWriter(writeToFile);
        using (writer)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Join("\n", readThrough));
            writer.Write(sb.ToString());
            Console.WriteLine("A {0} was created in the following work directory -> {1}", writeToFile, Environment.CurrentDirectory);
        }
    }

    private static string[] InsertRowNumebrs(params string[] textLines)
    {
        for (int index = 0; index < textLines.Length; index++)
        {
            textLines[index] = textLines[index].Insert(0, index + 1 + " ");
        }

        return textLines;
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