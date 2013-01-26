using System;

public class AddTwoNumbersAsArrays
{
    public static void Main()
    {
        int[] arrayOne = { 4, 5, 6 }; 
        int[] arrayTwo = { 7, 5, 2, 4 };
        PrintToConsole(AddArrays(arrayOne, arrayTwo));
    }

    public static void PrintToConsole(int[] array)
    {
        for (int index = 0; index < array.Length - 1; index++)
        {
            Console.Write(array[index]);
        }

        if (array[array.Length - 1] != 0)
        {
            Console.Write(array[array.Length - 1]);
        }

        Console.WriteLine();
    }

    public static int[] AddArrays(int[] arrayOne, int[] arrayTwo)
    {
        int[] arraySum = new int[Math.Max(arrayOne.Length, arrayTwo.Length) + 1];
        for (int index = 0; index < arraySum.Length - 1; index++)
        {
            int digitOne = GetDigit(arrayOne, index);
            int digitTwo = GetDigit(arrayTwo, index);
            arraySum[index + 1] = (arraySum[index] + digitOne + digitTwo) / 10;
            arraySum[index] = (arraySum[index] + digitOne + digitTwo) % 10;
        }

        return arraySum;
    }

    public static int GetDigit(int[] array, int index)
    {
        int digit = 0;
        if (index < array.Length)
        {
            digit = array[index];
        }

        return digit;
    }
}