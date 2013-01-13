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
        int[] myArray = new int[n];

        for (int i = 0; i < n; i++)
        {
            myArray[i] = i + 1;
        }
        int[] variation = new int[k];

        for (int i = 0; i < variation.Length; i++)
        {
            variation[i] = myArray[0];

        }

        while (true)
        {
            for (int i = 0; i < n; i++)
            {
                
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


