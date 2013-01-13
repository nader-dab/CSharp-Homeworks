using System;

class ChangeBitAtPositionP
{
    static void Main()
    {
        Console.WriteLine("Please enter a number");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter desired bit value");
        int v = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter desired position");
        int p = int.Parse(Console.ReadLine());
        int mask = 1;
        int nModded = n;
        if (v == 1)
        {
            mask = mask << p;
            nModded = mask | n; 
        }
        else if (v == 0)
        {
            mask = mask << p;
            nModded = ~mask & n;
        }
        Console.Write("n={0}(",n);
        Console.Write(Convert.ToString(n,2).PadLeft(8, '0'));
        Console.Write("), p={0}, v={1} -> {2}(",p,v,nModded);
        Console.WriteLine(Convert.ToString(nModded,2).PadLeft(8,'0') + ")");
    }
}

