using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Labyrinth3D
{
    struct Coordinates
    {
        public Coordinates(int x, int y, int z, int distance)
            : this()
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
            this.Distance = distance;
        }
        public int X { get; set; }
        public int Y { get; set; }
        public int Z { get; set; }
        public int Distance { get; set; }
    }

    class Program
    {
        static char[, ,] matrix;
        static void Main(string[] args)
        {
            string[] coordTokens = Console.ReadLine().Split(' ');
            int x = int.Parse(coordTokens[0]);
            int y = int.Parse(coordTokens[1]);
            int z = int.Parse(coordTokens[2]);

            Coordinates startingLocations = new Coordinates(x, y, z, 0);

            string[] dimentionTokens = Console.ReadLine().Split(' ');
            int l = int.Parse(dimentionTokens[0]);
            int r = int.Parse(dimentionTokens[1]);
            int c = int.Parse(dimentionTokens[2]);

             matrix = new char[l, r, c];

            for (int layer = 0; layer < l; layer++)
            {
                for (int row = 0; row < r; row++)
                {
                    string line = Console.ReadLine();
                    for (int column = 0; column < c; column++)
                    {
                        matrix[layer, row, column] = line[column];
                    }
                }
            }

            Queue<Coordinates> bfsMatrix = new Queue<Coordinates>();
            bfsMatrix.Enqueue(startingLocations);

            int result = 0;

            while (bfsMatrix.Count > 0)
            {
                Coordinates currentLocation = bfsMatrix.Dequeue();

                int layer = currentLocation.X;
                int row = currentLocation.Y;
                int column = currentLocation.Z;
                int distance = currentLocation.Distance;
                if (layer < 0|| layer >= matrix.GetLength(0)) // exit found
                {
                    result = distance;
                    break;
                }

                if (matrix[layer, row, column] == '#')
                {
                    continue;
                }

                AddCoordinatesToBfsMatrixQueue(layer, row - 1, column, distance + 1, bfsMatrix);
                AddCoordinatesToBfsMatrixQueue(layer, row + 1, column, distance + 1, bfsMatrix);
                AddCoordinatesToBfsMatrixQueue(layer, row, column - 1, distance + 1, bfsMatrix);
                AddCoordinatesToBfsMatrixQueue(layer, row, column + 1, distance + 1, bfsMatrix);

                if (matrix[layer, row, column] == 'U')
                {
                    AddCoordinatesToBfsMatrixQueue(layer + 1, row, column, distance + 1, bfsMatrix);
                }

                if (matrix[layer, row, column] == 'D')
                {
                    AddCoordinatesToBfsMatrixQueue(layer - 1, row, column, distance + 1, bfsMatrix);
                }

                matrix[layer, row, column] = '#';
            }

            Console.WriteLine(result);

        }

        private static void AddCoordinatesToBfsMatrixQueue(int layer, int row, int column, int distance,  Queue<Coordinates> bfsMatrix)
        {
            if (row >= 0 && row < matrix.GetLength(1) && column>=0 && column < matrix.GetLength(2))
            {
                bfsMatrix.Enqueue(new Coordinates(layer, row, column, distance));
            }
            
        }

    }
}
