using System;
using System.Collections.Generic;

class GenerateAllVariations
{
    static void Main()
    {
        Console.WriteLine("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter K: ");
        int k = int.Parse(Console.ReadLine());
        int[] myArray = new int[k];

        Variations(myArray, 0, n);
    }

    static void Variations(int[] array, int index, int limit)
    {
        if (index == array.Length)
        {
            PrintArray(array);
        }
        else
        {
            for (int i = 0; i <= limit; i++)
            {
                array[index] = i;
                Variations(array, index + 1, limit);
            }
        }

    }
    static void PrintArray(int[] array)
    {
        foreach (var item in array)
        {
            Console.Write(item + "");
        }
        Console.WriteLine();
    }
}


