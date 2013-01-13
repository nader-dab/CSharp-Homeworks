using System;

class CheckBitAtPositionP
{
    static void Main()
    {
        Console.WriteLine("Please enter a number");
        int v = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter desired position");
        int p = int.Parse(Console.ReadLine());
        int mask = 1;
        mask = mask << p;
        int bit = mask & v;
        bit = bit >> p;
        bool checkBit = (bit == 1);
        //Console.WriteLine(Convert.ToString(v, 2));
        Console.WriteLine("v={0}; p={1} -> {2}",v ,p, checkBit );        
    }
}

