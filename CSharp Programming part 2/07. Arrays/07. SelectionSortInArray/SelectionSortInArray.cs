using System;

class SelectionSortInArray
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
        for (int i = 0; i < myArray.GetLength(0); i++)
        {
            int minElement = int.MaxValue;
            int positionOfMin = i;
            for (int j = i; j < myArray.GetLength(0); j++)
            {
                if (myArray[j] < minElement)
                {
                    minElement = myArray[j];
                    positionOfMin = j;
                }  
            }
            int swap = myArray[i];
            myArray[i] = minElement;
            myArray[positionOfMin] = swap;
        }

        foreach (var item in myArray)
        {
            Console.WriteLine(item);
        }
    }
}

