using System;

class ExtractBitAtPositionB
{
    static void Main()
    {
        Console.WriteLine("Please enter a number");
        int i = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter desired position");
        int b = int.Parse(Console.ReadLine());
        int mask = 1;
        mask = mask << b;
        int bit = mask & i;
        bit = bit >> b;
        //Console.WriteLine(Convert.ToString(i,2));
        Console.WriteLine("i={0}; b={1} -> value={2}", i, b, bit);
    }
}

