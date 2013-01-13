using System;

class PrintPermutations
{
    static void Main()
    {
        Console.WriteLine("Enter N: ");
        int n = int.Parse(Console.ReadLine());
        
        int[] myArray = new int[n];
        for (int i = 0; i < myArray.GetLength(0); i++)
        {
            myArray[i] = i + 1;
        }
        for (int i = 0; i < myArray.GetLength(0) ; i++)
        {
            for (int j = myArray.GetLength(0) - 1; j > 0; j--)
            {
                int swap = myArray[j];
                myArray[j] = myArray[j - 1];
                myArray[j - 1] = swap;
                foreach (var item in myArray)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}

