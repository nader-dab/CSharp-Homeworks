using System;

class GreatestCommonDivisor
{
    static int EnterNumber()
    {
        string input;
        int number;
        do
        {
            Console.Write("Please enter a number:\t ");
            input = Console.ReadLine();
        } 
        while (!int.TryParse(input, out number) || number <= 0);
        return number;
    }

    static void Main()
    {
        /* Euclidean algorithm:
         * 1) If a<b, exchange a and b.
         * 2) Divide a by b and get the remainder, r. If r=0, report b as the GCD of a and b.
         * 3) Replace a by b and replace b by r. Return to the previous step.
         */
        int numberA = EnterNumber();
        int numberB = EnterNumber();
        int swapNumber;
        int remainder;
        int greatestCommonDivisor = 1;
        if (numberA < numberB)
	    {
		    swapNumber = numberB;
            numberB = numberA;
            numberA = swapNumber;
	    }
        do
        {
            remainder = numberA % numberB;
            if (remainder == 0)
            {
                greatestCommonDivisor = numberB;
            }
            else
            {
                numberA = numberB;
                numberB = remainder;
            }
        } 
        while (remainder != 0);
        Console.WriteLine("Greatest common divisor: {0}", greatestCommonDivisor);
    }
}

