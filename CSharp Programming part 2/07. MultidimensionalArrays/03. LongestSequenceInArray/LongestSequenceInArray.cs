using System;
using System.Collections.Generic;

public class LongestSequenceInArray
{
    public static void Main()
    {
        Console.WriteLine("Please enter number of rows N: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter number of columns M: ");
        int m = int.Parse(Console.ReadLine());

        string[,] matrix = new string[n, m];

        for (int row = 0; row < n; row++)
        {
            for (int col = 0; col < m; col++)
            {
                Console.Write("Enter element[{0},{1}]: ", row, col);
                matrix[row, col] = Console.ReadLine();
            }
        }

        /*Example
        string[,] matrix = {
                                {"ha", "hi","sa","re","xa"},
                                {"po", "ha","sa","xa","da"},
                                {"op", "hi","xa","re","po"},
                                {"ha", "xa","sa","ha","da"},
                                {"xa", "po","sa","ha","ha"}
                           
                           };*/

        List<string> currentSequence = new List<string>();
        List<string> bestSequence = new List<string>();

        // horizontal check
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            currentSequence = new List<string>();
            currentSequence.Add(matrix[row, 0]);
            for (int col = 1; col < matrix.GetLength(1); col++)
            {
                if (matrix[row, col] == currentSequence[currentSequence.Count - 1])
                {
                    currentSequence.Add(matrix[row, col]);
                }

                if (matrix[row, col] != currentSequence[currentSequence.Count - 1] || col == matrix.GetLength(1) - 1)
                {
                    if (bestSequence.Count < currentSequence.Count)
                    {
                        bestSequence = currentSequence;
                    }

                    currentSequence = new List<string>();
                    currentSequence.Add(matrix[row, col]);
                }
            }
        }

        // vertical check
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            currentSequence = new List<string>();
            currentSequence.Add(matrix[0, col]);
            for (int row = 1; row < matrix.GetLength(0); row++)
            {
                if (matrix[row, col] == currentSequence[currentSequence.Count - 1])
                {
                    currentSequence.Add(matrix[row, col]);
                }

                if (matrix[row, col] != currentSequence[currentSequence.Count - 1] || row == matrix.GetLength(1) - 1)
                {
                    if (bestSequence.Count < currentSequence.Count)
                    {
                        bestSequence = currentSequence;
                    }

                    currentSequence = new List<string>();
                    currentSequence.Add(matrix[row, col]);
                }
            }
        }

        // diagonal check top to bottom
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                currentSequence = new List<string>();
                currentSequence.Add(matrix[row, 0]);
                for (int checkRow = row + 1, checkCol = 1; checkRow < matrix.GetLength(0) && checkCol < matrix.GetLength(1); checkRow++, checkCol++)
                {
                    if (matrix[checkRow, checkCol] == currentSequence[currentSequence.Count - 1])
                    {
                        currentSequence.Add(matrix[checkRow, checkCol]);
                    }

                    if (matrix[checkRow, checkCol] != currentSequence[currentSequence.Count - 1] || checkCol == matrix.GetLength(1) - 1 || checkRow == matrix.GetLength(0) - 1)
                    {
                        if (bestSequence.Count < currentSequence.Count)
                        {
                            bestSequence = currentSequence;
                        }

                        currentSequence = new List<string>();
                        currentSequence.Add(matrix[checkRow, checkCol]);
                    }
                }
            }
        }

        // diagonal check bottom to top
        for (int col = 0; col < matrix.GetLength(1); col++)
        {
            for (int row = matrix.GetLength(0) - 1; row >= 0; row--)
            {
                currentSequence = new List<string>();
                currentSequence.Add(matrix[row, 0]);
                for (int checkRow = row - 1, checkCol = 1; checkRow >= 0 && checkCol < matrix.GetLength(1); checkRow--, checkCol++)
                {
                    if (matrix[checkRow, checkCol] == currentSequence[currentSequence.Count - 1])
                    {
                        currentSequence.Add(matrix[checkRow, checkCol]);
                    }

                    if (matrix[checkRow, checkCol] != currentSequence[currentSequence.Count - 1] || checkCol == matrix.GetLength(1) - 1 || checkRow == 0)
                    {
                        if (bestSequence.Count < currentSequence.Count)
                        {
                            bestSequence = currentSequence;
                        }

                        currentSequence = new List<string>();
                        currentSequence.Add(matrix[checkRow, checkCol]);
                    }
                }
            }
        }
        
        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            for (int col = 0; col < matrix.GetLength(1); col++)
            {
                Console.Write("{0,-5}", matrix[row, col]);
            }

            Console.WriteLine();
        }

        Console.Write("Longest sequence: ");
        foreach (var item in bestSequence)
        {
            Console.Write(item + " ");
        }

        Console.WriteLine();
    }
}