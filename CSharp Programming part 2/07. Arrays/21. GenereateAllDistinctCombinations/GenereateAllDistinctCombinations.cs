using System;
using System.Collections.Generic;

class GenereateAllDistinctCombinations
{
    static void Main()
    {
        Console.WriteLine("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter K: ");
        int k = int.Parse(Console.ReadLine());
        int[] myArray = new int[k];

        Combinatiobns(myArray, 0, n, 1);
    }

    static void Combinatiobns(int[] array, int index, int limit, int current)
    {
        if (index == array.Length)
        {
            PrintArray(array);
        }
        else
        {
            for (int i = current; i <= limit; i++)
            {
                array[index]= i;
                Combinatiobns(array, index + 1, limit, i + 1);
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

