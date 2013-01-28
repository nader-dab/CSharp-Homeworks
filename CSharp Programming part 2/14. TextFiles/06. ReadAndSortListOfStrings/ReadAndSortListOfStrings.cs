using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Text;

class ReadAndSortListOfStrings
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Please enter file location.");
            string fileName = Console.ReadLine();
            List<string> names = ReadThroughFile(fileName);
            names.Sort();
            CreateFile(names);

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

    private static void CreateFile(List<string> names)
    {
        string writeToFile = "result.txt";
        StreamWriter writer = new StreamWriter(writeToFile);
        using (writer)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Join("\n", names));
            writer.Write(sb.ToString());
            Console.WriteLine("A {0} was created in the following work directory -> {1}", writeToFile, Environment.CurrentDirectory);
        }
    }

    private static List<string> ReadThroughFile(string fileName)
    {
        StreamReader reader = new StreamReader(fileName);

        List<string> names = new List<string>();
        using (reader)
        {
            string line = reader.ReadLine();
            while (line!= null)
            {
                names.Add(line);
                line = reader.ReadLine();
            } 
        }

        return names;
    }
}