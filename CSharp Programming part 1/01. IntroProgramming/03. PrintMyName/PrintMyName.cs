using System;

class PrintMyName
{
    static void Main()
    {
        Console.WriteLine("Nader");
        char symbol = 0x64;
        Console.WriteLine("{0} {1}",symbol, Convert.ToString((int)symbol, 16));
        symbol = 'A'; 
        Console.WriteLine("{0} {1} \u03c0 ", symbol, (int)symbol);
        int charCode = 67;
        Console.WriteLine((char)charCode);
    
    }
}

