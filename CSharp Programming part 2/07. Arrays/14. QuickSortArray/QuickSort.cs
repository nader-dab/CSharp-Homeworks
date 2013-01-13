using System;
using System.Collections.Generic;

class QuickSortArray
{
    static void Main()
    {
        Console.Write("Enter array lenght: ");
        int arrayLenght = int.Parse(Console.ReadLine());
        List<int>myArray = new List<int>();
        for (int i = 0; i < arrayLenght; i++)
        {
            Console.Write("Enter element[{0}] = ", i);
            myArray.Add(int.Parse(Console.ReadLine()));
        }

        List<int> sortedArray = QuickSort(myArray);

        foreach (var item in sortedArray)
        {
            Console.WriteLine(item);
        }
    }

    static List<int> QuickSort(List<int> array)
    {
        if (array.Count <= 1)
        {
            return array;
        }

        int pivot = array[array.Count / 2];

        List<int> smaller = new List<int>();
        List<int> bigger = new List<int>();

        for (int index = 0; index < array.Count; index++)
        {
            if (index != array.Count/2)
            {
                if (array[index] <= pivot)
                {
                    smaller.Add(array[index]);
                }
                else
	            {
                    bigger.Add(array[index]);
	            }
            }
        }
        return MergeArrays(QuickSort(smaller), pivot, QuickSort(bigger));
    }

    static List<int> MergeArrays(List<int> smaller, int pivot, List<int> bigger)
    {
        List<int> merge = new List<int>();
        for (int index = 0; index < smaller.Count; index++)
        {
            merge.Add(smaller[index]);
        }

        merge.Add(pivot);

        for (int index = 0; index < bigger.Count; index++)
        {
            merge.Add(bigger[index]);
        }
        return merge;
    }
}

