using System;
using System.IO;
using System.Text;

class ReadSquareMatrixFile
{
    static void Main()
    {
        try
        {
            Console.WriteLine("Please enter file location.");
            string fileName = Console.ReadLine();
            int[,] matrix = ReadThroughFile(fileName);
            FindMaxSubMatrix(matrix);
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("The file path is empty.");
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Cannot find the specified file");
        }
        catch (DirectoryNotFoundException)
        {
            Console.WriteLine("Cannot find the specified file");
        }
        catch (NotSupportedException)
        {
            Console.WriteLine("Path is in invalid format.");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("The file is either read-only or you do not have the required permission.");
        }
        catch(ArgumentException ae)
        {
            Console.Error.WriteLine(ae.Message);
        }
    }

    private static void FindMaxSubMatrix(int[,] matrix)
    {
        int bestSum = int.MinValue;
        int bestRow = 0;
        int bestCol = 0;
        for (int row = 0; row < matrix.GetLength(0) - 1; row++)
        {
            for (int col = 0; col < matrix.GetLength(1) - 1; col++)
            {
                int sum = matrix[row, col] + matrix[row, col + 1]
                    + matrix[row + 1, col] + matrix[row + 1, col + 1];
                if (sum > bestSum)
                {
                    bestSum = sum;
                    bestRow = row;
                    bestCol = col;
                }
            }
        }

        CreateFile(bestSum.ToString());
    }

    private static void CreateFile(params string[] readThrough)
    {
        string writeToFile = "result.txt";
        StreamWriter writer = new StreamWriter(writeToFile);
        using (writer)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(string.Join("\n", readThrough));
            writer.Write(sb.ToString());
            Console.WriteLine("A {0} was created in the following work directory -> {1}", writeToFile, Environment.CurrentDirectory);
        }
    }

    private static int[,] ReadThroughFile(string fileName)
    {
        StreamReader reader = new StreamReader(fileName);
        using (reader)
        {
            int n = int.Parse(reader.ReadLine());

            int[,] matrix = new int[n, n];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] line = reader.ReadLine().Split(' ');
                if (line.Length != matrix.GetLength(0))
                {
                    throw new ArgumentException("Incorrect matrix data!");
                }

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = int.Parse(line[col]);
                }
            }

            return matrix;
        }
    }
}