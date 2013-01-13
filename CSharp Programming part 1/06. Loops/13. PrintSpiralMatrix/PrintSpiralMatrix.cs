using System;

class PrintSpiralMatrix
{
    static void Main()
    {
        int n;
        do
        {
            Console.Write("Please enter a number: ");    
        } 
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0 || n > 20);

        int[,] nMatrix = new int[n, n];
        int row = 0;
        int col = 0;
        int numbersToBeDrawn = n;
        int surroundingNumbers = 0;
        int number = 1;

        while (number <= n * n)
        {
            for (int i = 0; i < numbersToBeDrawn; i++)
            {
                col = i + surroundingNumbers;
                nMatrix[row, col] = number;
                number++;
            }
            numbersToBeDrawn--;

            for (int i = 1; i <= numbersToBeDrawn; i++)
            {
                row = i + surroundingNumbers;
                nMatrix[row, col] = number;
                number++;
            }
            numbersToBeDrawn--;
            for (int i = numbersToBeDrawn; i >= 0; i--)
            {
                col = i + surroundingNumbers;
                nMatrix[row, col] = number;
                number++;
            }
            for (int i = numbersToBeDrawn; i > 0; i--)
            {
                row = i + surroundingNumbers;
                nMatrix[row, col] = number;
                number++;
            }
            surroundingNumbers++;
        }

        for (int i = 0; i < n; i++)
        {
            for (int k = 0; k < n; k++)
            {
                Console.Write("{0, 4}", nMatrix[i,k]);
            }
            Console.WriteLine();
        }
    }
}

