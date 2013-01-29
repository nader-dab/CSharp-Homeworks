using System;

class CountSubstrings
{
    static void Main()
    {
        Console.WriteLine("Please enter a string.");
        string inputString = Console.ReadLine();
        Console.WriteLine("Please enter a substring.");
        string subString = Console.ReadLine();
        inputString = inputString.ToLower();
        subString = subString.ToLower();
        int count = 0;
        int index = -1;
        while (true)
        {
            index = inputString.IndexOf(subString, index + 1);
            if (index == - 1)
            {
                break;
            }

            count++;
        }

        Console.WriteLine("The substring is contained {0} times.", count);
    }
}
