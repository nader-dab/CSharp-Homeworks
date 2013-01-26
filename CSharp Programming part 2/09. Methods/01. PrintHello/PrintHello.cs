using System;

class PrintHello
{
    static void Main()
    {
        Console.WriteLine("Enter your name:");
        string name = Console.ReadLine();
        SayHello(name);
    }
    static void SayHello(string name)
    {
        Console.WriteLine("Hello, {0}!", name);
    }
}