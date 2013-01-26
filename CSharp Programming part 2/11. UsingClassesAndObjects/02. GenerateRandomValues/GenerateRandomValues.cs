using System;

class GenerateRandomValues
{
    static void Main()
    {
        Random rand = new Random();
        for (int index = 0; index < 10; index++)
        {
            Console.WriteLine(rand.Next(100, 201));
        }
    }
}