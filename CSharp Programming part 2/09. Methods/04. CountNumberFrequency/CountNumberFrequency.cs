using System;

public class CountNumberFrequency
{
    public static void Main()
    {
        Console.Write("Please enter lenght of the array: ");
        int length = int.Parse(Console.ReadLine());
        int[] array = new int[5];
        for (int index = 0; index < length; index++)
        {
            Console.Write("Please enter element[{0}]: ", index);
            array[index] = int.Parse(Console.ReadLine());
        }

        Console.Write("Please enter number to search in the array: ");
        int number = int.Parse(Console.ReadLine());

        int frequency = CheckFrequency(array, number);
        Console.WriteLine("The number {0} appears {1} times.", number, frequency);
    }

    public static int CheckFrequency(int[] array, int number)
    {
        int frequency = 0;
        for (int index = 0; index < array.Length; index++)
        {
            if (array[index] == number)
            {
                frequency++;
            }
        }

        return frequency;
    }
}