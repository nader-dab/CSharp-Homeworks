using System;

class InitializeArray
{
    static void Main()
    {
        int[] array = new int[20];

        for (int index = 0; index < array.GetLength(0); index++)
        {
            array[index] = index * 5;
        }

        for (int index = 0; index < array.GetLength(0); index++)
        {
            Console.WriteLine("Element[{0}] = {1}", index, array[index]);
        }
    }
}

