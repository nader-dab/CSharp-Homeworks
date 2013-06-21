using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _09.LargestAreaOfAdjecentCells
{
    class Program
    {
        static char[,] matrix = new char[,]
        {
            {' ', ' ', ' ', '*', ' ' },
            {'*', '*', ' ', '*', ' ' },
            {' ', ' ', ' ', '*', ' ' },
            {' ', '*', '*', '*', ' ' },
            {' ', '*', ' ', ' ', '*' },
        };



        static void Main(string[] args)
        {
            int areaSize = 0;
            int areaIndex = 0;
            int maxArea = 0;
            int maxAreaIndex = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (matrix[row, col] != ' ')
                    {
                        continue;
                    }

                    areaIndex++;
                    areaSize = ExploreArea(row, col, areaIndex, 0);

                    if (areaSize > maxArea)
                    {
                        maxArea = areaSize;
                        maxAreaIndex = areaIndex;
                    }
                }
            }

            PrintMatrix();
            Console.WriteLine("Largest Area ");
            Console.WriteLine("{0} -> {1}", maxAreaIndex, maxArea);
        }


        private static int ExploreArea(int row, int col, int areaIndex, int areaSize)
        {

            if (row < 0 || col < 0 || row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return areaSize;
            }

            if (matrix[row, col] != ' ')
            {
                return areaSize;
            }
            matrix[row, col] = areaIndex.ToString()[0];
            areaSize++;
            areaSize = ExploreArea(row, col + 1, areaIndex, areaSize);
            areaSize = ExploreArea(row + 1, col, areaIndex, areaSize);
            areaSize = ExploreArea(row, col - 1, areaIndex, areaSize);
            areaSize = ExploreArea(row - 1, col, areaIndex, areaSize);
            return areaSize;
        }

        static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }
    }
}
