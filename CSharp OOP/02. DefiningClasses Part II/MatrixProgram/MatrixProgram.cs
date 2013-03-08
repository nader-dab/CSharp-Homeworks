namespace MatrixProgram
{
    using System;
    using Generator;
    using MatrixLibrary;
    using VersionLibrary;

    [Version(1, 3)]
    public class MatrixProgram
    {
        // Task 8, 9, 10, 11
        public static void Main(string[] args)
        {
            Matrix<int> matrixOne = new Matrix<int>(5, 5);
            Matrix<int> matrixTwo = new Matrix<int>(5, 5);

            for (int row = 0; row < matrixOne.GetLength(0); row++)
            {
                for (int col = 0; col < matrixOne.GetLength(1); col++)
                {
                    matrixOne[row, col] = RandomGenerator.Next(0, 9);
                    matrixTwo[row, col] = RandomGenerator.Next(0, 9);
                }
            }

            Console.WriteLine("Matrix one:");
            Console.WriteLine(matrixOne);
            Console.WriteLine();

            Console.WriteLine("Matrix two:");
            Console.WriteLine(matrixTwo);
            Console.WriteLine();

            Console.WriteLine("Addition");
            Console.WriteLine(matrixOne + matrixTwo);
            Console.WriteLine();

            Console.WriteLine("Substraction");
            Console.WriteLine(matrixOne - matrixTwo);
            Console.WriteLine();

            Console.WriteLine("Multiplication");
            Console.WriteLine(matrixOne * matrixTwo);
            Console.WriteLine();

            if (matrixOne)
            {
                Console.WriteLine("This will not print");
            }

            matrixOne = new Matrix<int>(8, 8);

            if (matrixOne)
            {
                Console.WriteLine("This will print");
            }

            Type type = typeof(MatrixProgram);
            object[] allAtributes = type.GetCustomAttributes(false);

            foreach (VersionAttribute attr in allAtributes)
            {
                Console.WriteLine("This version is: {0}", attr);
            }
        }
    }
}
