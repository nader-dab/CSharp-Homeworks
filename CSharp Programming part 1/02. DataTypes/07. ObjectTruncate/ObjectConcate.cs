using System;

class ObjectTruncate
{
    static void Main()
    {
        string firstString = "Hello";
        string secondString = "World";
        firstString = firstString + " " + secondString;
        object concateString = firstString;
        Console.WriteLine(concateString);
    }
}

