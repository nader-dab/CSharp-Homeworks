using System;

class PrintMatrix
{
    static void Main()
    {
        Console.Write("Enter N = ");
        int n = int.Parse(Console.ReadLine());
        //A)
        Console.WriteLine("A)");
        int[,] matrix = new int[n, n];
        int counter = 1;
        for (int col = 0; col < n; col++)
        {
            for (int row = 0; row < n; row++)
            {
                matrix[row, col] = counter;
                counter++;
            }
            
        }
        PrintMatrixToConsole(matrix);
        //B)
        Console.WriteLine("B)");
        matrix = new int[n, n];
        counter = 1;
        for (int col = 0; col < n; col++)
        {
            if (col % 2 == 0)
            {
                for (int row = 0; row < n; row++)
                {
                    matrix[row, col] = counter;
                    counter++;
                }
            }
            else
            {
                for (int row = n - 1 ; row >= 0; row--)
                {
                    matrix[row, col] = counter;
                    counter++;
                }
            }
            
        }
        PrintMatrixToConsole(matrix);
        //C)
        Console.WriteLine("C)");
        matrix = new int[n, n];
        counter = 1;
        int radius = 0;
        while (counter <= n*n)
        {
            for (int row = 0; row < n; row++)
            {
                for (int col = 0; col < n; col++)
                {
                    if (row == radius && col == radius)
                    {
                        matrix[row, col] = counter;
                        counter++;
                    }
                }
            }
            radius++;
        }
        PrintMatrixToConsole(matrix);
        //D)
        Console.WriteLine("D)");
        matrix = new int[n, n];
        counter = 1;
        int cycle = 0;
        while (counter <= n*n)
        {
            int row = 0 + cycle;
            int col = 0 + cycle;

            for (int i = 0; i < n - 2*cycle; i++)
            {
                matrix[row, col] = counter;
                row++;
                counter++;
            }
            row--;
            col++;
            for (int i = 0; i < n - 2*cycle - 1; i++)
            {
                matrix[row, col] = counter;
                col++;
                counter++;
            }
            col--;
            row--;
            for (int i = 0; i < n - 2*cycle - 1; i++)
            {
                matrix[row, col] = counter;
                row--;
                counter++;
            }
            row++;
            col--;
            for (int i = 0; i <  n - 2*cycle - 2; i++)
            {
                matrix[row, col] = counter;
                col--;
                counter++;
            }
            cycle++;
        }
        PrintMatrixToConsole(matrix);
    }

    static void PrintMatrixToConsole(int[,] matrix)
    {
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,3}",matrix[row,col]);
            }
            Console.WriteLine();
        }
    }
}

