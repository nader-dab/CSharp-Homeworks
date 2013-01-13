using System;

class ObjectTruncate
{
    static void Main()
    {
        string firstString = "Hello";
        string secondString = "World";
        firstString = firstString + " " + secondString;
        object concateString = firstString;
        string thirdString = concateString.ToString();
        Console.WriteLine(thirdString);
    }
}

