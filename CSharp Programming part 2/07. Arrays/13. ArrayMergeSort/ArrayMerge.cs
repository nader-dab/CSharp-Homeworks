using System;
using System.Collections.Generic;

class MergeSort
{
    static void Main()
    {
        Console.Write("Enter desired number of elements N: ");
        int arrayLenght = int.Parse(Console.ReadLine());
        List<int> myArray = new List<int>();
        for (int i = 0; i < arrayLenght; i++)
        {
            Console.Write("Enter element[{0}] = ", i);
            myArray.Add(int.Parse(Console.ReadLine()));
        }

        List<int> sortedArray = Sort(myArray);

        foreach (var item in sortedArray)
        {
            Console.WriteLine(item);
        }
    }
    static List<int> Sort(List<int> array)
    {
        List<int> left = new List<int>();
        List<int> right = new List<int>();
        List<int> merge = new List<int>();

        if (array.Count > 1)
        {
            foreach (var item in array)
            {
                if (left.Count< array.Count/2)
                {
                    left.Add(item);
                }
                else
                {
                    right.Add(item);
                }
            }
            List<int> sortLeft = Sort(left);
            List<int> sortRight = Sort(right);
            merge = MergeLists(sortLeft, sortRight);
        }
        else
        {
            merge.Add(array[0]);
        }
        return merge;
    }

    static List<int> MergeLists(List<int> left, List<int> right)
    {
        List<int> merge = new List<int>();
        while (left.Count>0 && right.Count>0)
        {
            if (left[0] < right[0])
            {
                merge.Add(left[0]);
                left.RemoveAt(0);
            }
            else
            {
                merge.Add(right[0]);
                right.RemoveAt(0);
            }
        }
        foreach (var item in left)
        {
            merge.Add(item);
        }
        foreach (var item in right)
        {
            merge.Add(item);
        }
        return merge;
    }
}

