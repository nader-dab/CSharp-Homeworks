namespace WalkInMatrix
{
    using System;

    public class Matrix
    {
        public const int MaxSize = 100;

        public static int ReadInput()
        {
            Console.WriteLine("Enter a positive number: ");
            string input = Console.ReadLine();
            int n = 0;

            while (!int.TryParse(input, out n) || n < 0 || n > MaxSize)
            {
                Console.WriteLine("You haven't entered a correct positive number");
                input = Console.ReadLine();
            }

            return n;
        }

        public static void Main(string[] args)
        {
            int n = ReadInput();
            WalkInMatrix matrix = new WalkInMatrix(n);
            matrix.PrintMatrixToConsole();
        }
    }
}