using System;

class FindMatrixInsideMatrix
{
    static void Main()
    {
        int n = 0;
        int m = 0;
        do
        {
	        Console.WriteLine("Please enter N (N > 3):");
        } 
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 3);
        do
        {
            Console.WriteLine("Please enter M (M > 3):");
        } 
        while (!int.TryParse(Console.ReadLine(), out m) || m <= 3);

        int[,] matrix = new int[n,m];

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                Console.Write("Enter element [{0},{1}] = ", row,col);
                matrix[row, col] = int.Parse(Console.ReadLine());
            }
        }
        int bestSum = int.MinValue;
        int bestRow = 0;
        int bestCol = 0;
        for (int row = 0; row < n - 2; row++)
        {
            
            for (int col = 0; col < m - 2; col++)
            {
                int sum = matrix[row, col] + matrix[row, col + 1] + matrix[row, col + 2]
                    + matrix[row + 1, col] + matrix[row + 1, col + 1] + matrix[row + 1, col + 2]
                    + matrix[row + 2, col] + matrix[row + 2, col + 1] + matrix[row + 2, col + 2];
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }
        for (int row = bestRow; row < bestRow + 3; row++)
        {
            for (int col = bestCol; col < bestCol + 3; col++)
            {
                Console.Write("{0, 3}", matrix[row,col]);
            }
            Console.WriteLine();
        }
    }
}

