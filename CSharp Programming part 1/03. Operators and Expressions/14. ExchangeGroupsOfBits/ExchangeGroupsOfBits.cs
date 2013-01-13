using System;

class ExchangeGroupsOfBits
{
    static void Main()
    {
        uint originalNumber = 0;
        bool isN = false;
        while (!isN)
        {
            Console.WriteLine("Enter a number:");
            isN = uint.TryParse(Console.ReadLine(), out originalNumber);
        }
        
        byte p = 0;
        bool isP = false;
        while(!isP)
        {
            Console.WriteLine("Enter first bit position between 0 and 31:");
            isP = ((byte.TryParse(Console.ReadLine(), out p)) && (p >= 0) && (p <= 31));
        }

        byte q = 0;
        bool isQ = false;
        while (!isQ)
        {
            Console.WriteLine("Enter second bit position between 0 and 31:");
            isQ = (byte.TryParse(Console.ReadLine(), out q) && (q >= 0) && (q <= 31));
        }

        byte allowedRange = (byte)Math.Min((32 - Math.Max(p, q)), Math.Abs(p - q));

        byte k = 0;
        bool isK = false;
        while(!isK)
        {
            Console.WriteLine("Enter desired number of bits between 0 and {0}:", allowedRange);
            isK = (byte.TryParse(Console.ReadLine(), out k) && (k >= 0) && (k <= allowedRange));
        }

        uint moddedNumber = originalNumber;
        for (int i = 0; i < k; i++)
        {
            uint mask1 = 1;
            uint mask2 = 1;

            mask1 = mask1 << p + i;
            mask2 = mask2 << q + i;

            uint bit1 = moddedNumber & mask1;
            uint bit2 = moddedNumber & mask2;

            bit1 = bit1 >> p + i;
            bit2 = bit2 >> q + i;

            if (bit1 == 1)
            {
                moddedNumber = moddedNumber | mask2;
            }
            else
            {
                moddedNumber = moddedNumber & ~mask2;
            }

            if (bit2 == 1)
            {
                moddedNumber = moddedNumber | mask1;
            }
            else
            {
                moddedNumber = moddedNumber & ~mask1;
            }
        }

        string line = new string('-', 32);
        Console.WriteLine(line);
        Console.WriteLine("10987654321098765432109876543210 \t Bit positions.");
        Console.WriteLine(line);
        Console.WriteLine(Convert.ToString(originalNumber, 2).PadLeft(32, '0') + " \t Original number.");
        Console.WriteLine(line);
        Console.WriteLine(Convert.ToString(moddedNumber, 2).PadLeft(32, '0') + " \t Modded number.");
        Console.WriteLine(line);
    }
}