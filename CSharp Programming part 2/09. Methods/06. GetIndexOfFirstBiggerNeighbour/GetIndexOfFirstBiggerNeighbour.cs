using System;

public class GetIndexOfFirstBiggerNeighbour
{
    public static void Main()
    {
        int[] array = new int[] { 4, 5, 6, 123, 235, 12, 67, 34, 34, 32 };
        int firstBiggerNeighbour = FindtBiggerNeighbour(array);
        Console.WriteLine(firstBiggerNeighbour);
    }
  
    public static int FindtBiggerNeighbour(int[] array)
    {
        for (int index = 0; index < array.Length; index++)
        {
            bool isItBigger = CheckSuroundingNeighbours(index, array);
            if (isItBigger)
            {
                return index;
            }
        }

        return -1;
    }

    public static bool CheckSuroundingNeighbours(int index, int[] array)
    {
        bool biggerThanLeft = CheckLeft(index, array);

        bool biggerThanRight = CheckRight(index, array);

        return biggerThanLeft & biggerThanRight;
    }

    public static bool CheckRight(int index, int[] array)
    {
        bool biggerThanRight = true;
        if (index < array.Length - 1 && array[index] < array[index + 1])
        {
            biggerThanRight = false;
        }

        return biggerThanRight;
    }

    public static bool CheckLeft(int index, int[] array)
    {
        bool biggerThanLeft = true;
        if (index > 0 && array[index] < array[index - 1])
        {
            biggerThanLeft = false;
        }

        return biggerThanLeft;
    }
}