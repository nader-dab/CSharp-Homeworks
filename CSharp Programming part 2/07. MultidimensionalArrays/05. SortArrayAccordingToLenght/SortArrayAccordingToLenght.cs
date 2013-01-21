using System;

public class SortArrayAccordingToLenght
{
    public static void Main()
    {
        Console.WriteLine("Please enter lenght of the array N: ");
        int n = int.Parse(Console.ReadLine());

        string[] array = new string[n];
        for (int index = 0; index < array.Length; index++)
        {
            Console.Write("Enter element[{0}] = ", index);
            array[index] = Console.ReadLine();
        }

        Array.Sort(array, (x, y) => x.Length.CompareTo(y.Length));
        foreach (var item in array)
        {
            Console.WriteLine(item);
        }
    }
}