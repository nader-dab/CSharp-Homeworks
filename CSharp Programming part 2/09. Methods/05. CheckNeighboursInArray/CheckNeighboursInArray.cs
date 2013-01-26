using System;

public class CheckNeighboursInArray
{
    public static void Main()
    {
        int[] array = new int[] { 4, 2, 3, 123, 23, 12, 67, 34, 34, 32 };
        int checkIndex = 0;
        bool isItBigger = CheckSuroundingNeighbours(checkIndex, array);
        if (isItBigger)
        {
            Console.WriteLine("The element is BIGGER than its surrounding neighbours");
        }
        else
        {
            Console.WriteLine("The element is Smaller than its surrounding neighbours");
        }
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