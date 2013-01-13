using System;

class CheckThirdBit
{
    static void Main()
    {
        Console.WriteLine("Please enter a number");
        int number = int.Parse(Console.ReadLine());
        int mask = 1;
        mask = mask << 3;
        int bit = mask & number;
        bit = bit >> 3;
        Console.WriteLine(Convert.ToString(number, 2));
        Console.WriteLine((bit == 0)?
            "The third bit is 0":
            "The third bit is 1");
    }
}

