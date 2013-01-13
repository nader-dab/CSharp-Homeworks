using System;

class ExchangeBitsInNumber
{
    static void Main()
    {
        Console.WriteLine("Please enter a number");
        uint number = uint.Parse(Console.ReadLine());
        uint moddedNumber = number;

        for (int i = 3; i <= 5; i++)
        {
            uint mask1 = 1;
            uint mask2 = 1;


            mask1 = mask1 << i;
            uint bit1 = mask1 & moddedNumber;
            bit1 = bit1 >> i;

            mask2 = mask2 << (i + 21);
            uint bit2 = mask2 & moddedNumber;
            bit2 = bit2 >> (i + 21);

            if (bit1 == 1)
            {
                moddedNumber = mask2 | moddedNumber;
            }
            else
            {
                moddedNumber = ~mask2 & moddedNumber;
            }

            if (bit2 == 1)
            {
                moddedNumber = mask1 | moddedNumber;
            }
            else
            {
                moddedNumber = ~mask1 & moddedNumber;
            }

        }

        Console.WriteLine(Convert.ToString(number, 2).PadLeft(32, '0'));
        Console.WriteLine(Convert.ToString(moddedNumber, 2).PadLeft(32, '0'));

    }
}

