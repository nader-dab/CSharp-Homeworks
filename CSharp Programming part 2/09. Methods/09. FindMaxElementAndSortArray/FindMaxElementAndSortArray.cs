using System;

public class FindMaxElementAndSortArray
{
    public static void Main()
    {
        int[] array = { 4, 5, 4, 34, 45, 11, 19, 21, 1, 37, 17, 24 };
        int startIndex = 1;
        int biggestElementIndex = FindMaxIndex(array, startIndex, array.Length);
        Console.WriteLine(string.Join(" ", array));
        Console.WriteLine("The biggest elemts is at index {0}", biggestElementIndex);
        SortAsscending(array);
        Console.WriteLine(string.Join(" ", array));
        SortDescending(array);
        Console.WriteLine(string.Join(" ", array));
    }

    public static void SortDescending(int[] array)
    {
        for (int index = 0; index < array.Length; index++)
        {
            int maxPivot = FindMaxIndex(array, index, array.Length);
            int swap = array[index];
            array[index] = array[maxPivot];
            array[maxPivot] = swap;
        }
    }

    public static void SortAsscending(int[] array)
    {
        for (int index = array.Length - 1; index >= 0; index--)
        {
            int maxPivot = FindMaxIndex(array, 0, index);
            int swap = array[index];
            array[index] = array[maxPivot];
            array[maxPivot] = swap;
        }
    }

    public static int FindMaxIndex(int[] array, int startIndex, int endIndex)
    {
        int maxIndex = startIndex;
        int maxElement = array[startIndex];
        for (int index = startIndex + 1; index < endIndex; index++)
        {
            if (array[index] > maxElement)
            {
                maxIndex = index;
                maxElement = array[index];
            }
        }

        return maxIndex;
    }
}