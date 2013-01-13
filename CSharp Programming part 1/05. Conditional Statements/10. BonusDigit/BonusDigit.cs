using System;

class BonusDigit
{
    static void Main()
    {
        int digit;
        Console.Write("Please enter a digit: ");
        while (true)
        {
            if (int.TryParse(Console.ReadLine(), out digit))
            {
                break;  
            }
            Console.Write("Incorrect Input. Please enter a propper value: ");
        }

        switch (digit)
        {
            case 1:
            case 2:
            case 3:
            {
                digit = digit * 10;
                Console.WriteLine(digit);
                break;
            }
            case 4:
            case 5:
            case 6:
            {
                digit = digit * 100;
                Console.WriteLine(digit);
                break;
            }
            case 7:
            case 8:
            case 9:
            {
                digit = digit * 1000;
                Console.WriteLine(digit);
                break;
            }
            default:
            {
                Console.WriteLine("Error!");
                break;
            }
        }
    }
}

