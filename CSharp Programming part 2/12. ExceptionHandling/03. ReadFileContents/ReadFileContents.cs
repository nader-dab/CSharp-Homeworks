using System;
using System.IO;
using System.Security;

class ReadFileContents
{
    static void Main()
    {
        Console.WriteLine("Please enter full path to the file: ");
        string path = Console.ReadLine();
        ReadFile(path);  
    }

    private static void ReadFile(string path)
    {
        try
        {
            string content = File.ReadAllText(path);
            Console.WriteLine("The contents of the file: ");
            Console.WriteLine(content);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The file path is empty.");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Cannot locate the specified directory.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Cannot locate the specified file.");
        }
        catch (PathTooLongException)
        {
            Console.WriteLine("The specified file location exceeeds the system-defined maximum length.");
        }
        catch (IOException)
        {
            Console.WriteLine("An I/O error occured while opening the file.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("The file is either read-only or you do not have the required permission.");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Path is in invalid format.");
        }
        catch (SecurityException)
        {
            Console.WriteLine("You do not have the required permission.");
        }
    }
}