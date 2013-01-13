using System;
using System.Collections.Generic;

class RemoveElementsToGetArraySorted
{
    static void Main()
    {
        Console.WriteLine("Please enter N:");
        int n = int.Parse(Console.ReadLine());
        int[] myArray = new int[n];
        List<int> sortedNumbers = new List<int>();
        List<int> bestSortedNumbers = new List<int>();

        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element[{0}]= ", i);
            myArray[i] = int.Parse(Console.ReadLine());

        }
        for (int i = 0; i < Math.Pow(2,n) - 1; i++)
        {
            sortedNumbers = new List<int>();
            for (int j = 0; j < n; j++)
            {
                if (((1 << j) & i) != 0)
                {
                    if (sortedNumbers.Count > 0 && sortedNumbers[sortedNumbers.Count - 1] <= myArray[j])
                    {
                        sortedNumbers.Add(myArray[j]);
                    }
                    if (sortedNumbers.Count == 0)
                    {
                        sortedNumbers.Add(myArray[j]);
                    }
                }
            }
            if (bestSortedNumbers.Count < sortedNumbers.Count)
            {
                bestSortedNumbers = sortedNumbers;
            }
        }
        
        if (bestSortedNumbers.Count > 0)
        {
            foreach (var item in bestSortedNumbers)
            {
                Console.Write(item + " ");
            }
        }
    }
}