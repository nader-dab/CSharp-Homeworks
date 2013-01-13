using System;

class IndexBinarySearch
{
    static void Main()
    {
        Console.Write("Enter array lenght: ");
        int arrayLenght = int.Parse(Console.ReadLine());
        int[] myArray = new int[arrayLenght];
        for (int i = 0; i < arrayLenght; i++)
        {
            Console.Write("Enter element[{0}] = ", i);
            myArray[i] = int.Parse(Console.ReadLine());
        }

        for (int i = 0; i < arrayLenght; i++)
        {
            int min = int.MaxValue;
            int minPosition = i;
            for (int j = i; j < arrayLenght; j++)
            {
                if (myArray[j]< min)
                {
                    min = myArray[j];
                    minPosition = j;
                }
            }
            int swap = myArray[i];
            myArray[i] = min;
            myArray[minPosition] = swap;
        }
        
        Console.Write("Find index for element: ");
        int findElement = int.Parse(Console.ReadLine());
        Console.WriteLine("Sorted array");
        for (int i = 0; i < myArray.GetLength(0); i++)
        {
            Console.WriteLine("Element[{0}] = {1}", i, myArray[i]);
        }
        int compare = myArray.GetLength(0) / 2;
        bool find = false;
        //Binary search
        while (compare > 0 && compare < myArray.GetLength(0))
        {
            if (myArray[compare] == findElement)
            {
                find = true;
                break;
            }
            else if (myArray[compare] > findElement)
            {
                compare = compare / 2;
            }
            else
            {
                compare = compare + compare / 2;
            }
        }
        if (find == true)
        {
            Console.WriteLine("The index for {0} is {1}", findElement, compare);
        }
        else
        {
            Console.WriteLine("No such element in the array");
        }

    }
}

