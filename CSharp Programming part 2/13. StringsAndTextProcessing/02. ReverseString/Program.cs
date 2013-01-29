using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Please enter a string: ");
        string input = Console.ReadLine();
        char[] array = input.ToCharArray();
        Array.Reverse(array);
        string reversedInput = new string(array);
        Console.WriteLine("The reversed string: {0}", reversedInput);
    }
}