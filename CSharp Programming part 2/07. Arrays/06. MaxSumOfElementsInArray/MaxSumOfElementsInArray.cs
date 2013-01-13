using System;

class MaxSumOfElementsInArray
{
    static void Main()
    {
        Console.Write("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Enter K: ");
        int k = int.Parse(Console.ReadLine());
        int[] myArray = new int[n];
        for (int i = 0; i < n; i++)
        {
            Console.Write("Enter element[{0}] = ", i);
            myArray[i] = int.Parse(Console.ReadLine());
        }
        int maxSum = int.MinValue;
        int bestStart = 0;

        for (int i = 0; i < myArray.GetLength(0) - k +1; i++)
        {
            int sum = 0;
            for (int j = 0; j < k; j++)
			{
                sum += myArray[i+j];
			}

            if (sum > maxSum)
            {
                maxSum = sum;
                bestStart = i;
            }
             
        }
        Console.Write("Best sum of elements is : {");
        for (int i = 0; i < k; i++)
        {
            Console.Write("{0}", myArray[i + bestStart]);
            if (i!= k - 1)
            {
                Console.Write(", ");
            }
        }
        Console.WriteLine("}");
    }
}

