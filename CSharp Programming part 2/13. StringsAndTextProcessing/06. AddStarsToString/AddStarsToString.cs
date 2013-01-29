using System;

class AddStarsToString
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a string.");
        string inputString = Console.ReadLine();
        if (inputString.Length < 20)
        {
            inputString = inputString.PadRight(20, '*');
        }

        Console.WriteLine(inputString);
    }
}
