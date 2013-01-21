using System;

public class ArrayBinSearch
{
    public static void Main()
    {
        Console.WriteLine("Please enter lenght of the array N: ");
        int n = int.Parse(Console.ReadLine());
       
        int[] array = new int[n];
        for (int index = 0; index < array.Length; index++)
        {
            Console.Write("Enter element[{0}] = ", index);
            array[index] = int.Parse(Console.ReadLine());
        }

        Array.Sort(array);
        foreach (var item in array)
        {
            Console.WriteLine(item);
        }

        Console.WriteLine("Please enter K: ");
        int k = int.Parse(Console.ReadLine());

        int indexLocation = Array.BinarySearch(array, k);
        if (indexLocation <= 0)
        {
            indexLocation = Math.Abs(indexLocation) - 2;
            if (indexLocation >= 0)
            {
                Console.WriteLine("The closest element to K={0} is {1}", k, array[indexLocation]);
            }
            else
            {
                Console.WriteLine("There are no smaller elements than K");
            }
        }
        else
        {
            Console.WriteLine("Found a match equal to k -> {0}", array[indexLocation]);
        }
    }
}