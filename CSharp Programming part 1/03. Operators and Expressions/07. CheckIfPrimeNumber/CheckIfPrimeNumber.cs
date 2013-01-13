using System;

class CheckIfPrimeNumber
{
    static void Main()
    {
        Console.WriteLine("Please enter a number.");
        uint n = uint.Parse(Console.ReadLine());
        bool checkPrime = true;
        for (int i = 2; i < n; i++)
        {
            if ((n % i) == 0)
            {
                checkPrime = false;
            }
        }
        Console.WriteLine(checkPrime == true?
            "The number you have entered is a prime number":
            "The number you have entered is NOT a prime number");
    }
}

