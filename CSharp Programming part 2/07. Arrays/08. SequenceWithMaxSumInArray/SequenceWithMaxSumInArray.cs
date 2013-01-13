using System;

class SequenceWithMaxSumInArray
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
        int maxSum = int.MinValue;
        
        int bestStart = 0;
        int bestFin = 0;
        for (int i = 0; i < myArray.GetLength(0); i++)
        {
            int sum = 0;
            for (int j = i; j < myArray.GetLength(0); j++)
            {
                sum += myArray[j];
                if (sum > maxSum)
                {
                    maxSum = sum;
                    bestStart = i;
                    bestFin = j;
                }
            }
        }
        Console.Write("Best sum = {");
        for (int i = bestStart; i < bestFin+1; i++)
        {
            Console.Write(myArray[i]);
            if (i != bestFin)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("}");

    }
}

