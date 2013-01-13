using System;

class PrimeNumbersEratosthenes
{
    static void Main()
    {
        int[] numbers = new int[10000001];

        for (int i = 2; i < numbers.GetLength(0); i++)
        {
            numbers[i] = i;
        }
        int prime = 0;
        for (int i = 2; i < numbers.GetLength(0); i++)
        {
            if (numbers[i] >= prime)
            {
                prime = numbers[i];

                for (int increment = 2 * prime; increment < numbers[numbers.GetLength(0) - 1]; increment += prime)
                {
                    numbers[increment] = 0;
                }
            }
        }
        foreach (var item in numbers)
        {
            if (item != 0)
	        {
		        Console.Write(item +" ");
	        }
        }
    }
}

