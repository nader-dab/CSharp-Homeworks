namespace _14.Labirinth
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Labirinth
    {
        private struct Cell
        {
            public int Row { get; set; }
            public int Col { get; set; }
            public int Distance { get; set; }
        }

        public const string EmptyCell = "0";
        public const string StartingCell = "*";
        public const string UnreachableCell = "u";

        private static string[,] labirinth = new string[,] 
        { 
            { "0", "0", "0", "x", "0", "x" },
            { "0", "x", "0", "x", "0", "x" },
            { "0", "*", "x", "0", "x", "0" },
            { "0", "x", "0", "0", "0", "0" },
            { "0", "0", "0", "x", "x", "0" },
            { "0", "0", "0", "x", "0", "x" },
        };

        public static void Main(string[] args)
        {
            Console.WriteLine("Start: ");
            PrintLabirinth(labirinth);

            Cell startingCell = FindEntryCell(labirinth);

            Queue<Cell> bfsLabirinthCells = new Queue<Cell>();
            bfsLabirinthCells.Enqueue(startingCell);

            while (bfsLabirinthCells.Count > 0)
            {
                Cell currentCell = bfsLabirinthCells.Dequeue();
                
                int row = currentCell.Row;
                int col = currentCell.Col;
                int distance = currentCell.Distance + 1;

                AddCellToQueue(row - 1, col, distance, bfsLabirinthCells);
                AddCellToQueue(row + 1, col, distance, bfsLabirinthCells); 
                AddCellToQueue(row, col - 1, distance, bfsLabirinthCells); 
                AddCellToQueue(row, col + 1, distance, bfsLabirinthCells);
            }

            PlaceUnreachableCells(labirinth);

            Console.WriteLine("Finish: ");
            PrintLabirinth(labirinth);
        }

        private static void AddCellToQueue(int row, int col, int distance, Queue<Cell> bfsLabirinthCells)
        {
            if (IsCellInLabirinth(row, col) && labirinth[row, col] == EmptyCell)
            {
                labirinth[row, col] = distance.ToString();

                Cell newCell = new Cell()
                {
                    Row = row,
                    Col = col,
                    Distance = distance
                };

                bfsLabirinthCells.Enqueue(newCell);
            }
        }

        private static bool IsCellInLabirinth(int row, int col)
        {
            bool isInRow = row >= 0 && row < labirinth.GetLength(0);
            bool isInCol = col >= 0 && col < labirinth.GetLength(1);
            bool result = isInRow && isInCol;
            return result;
        }

        private static void PrintLabirinth(string[,] labirinth)
        {
            for (int row = 0; row < labirinth.GetLength(0); row++)
            {
                for (int col = 0; col < labirinth.GetLength(1); col++)
                {
                    Console.Write("{0, 3}", labirinth[row, col]);
                }
                Console.WriteLine();
            }
        }

        private static Cell FindEntryCell(string[,] labirinth)
        {
            for (int row = 0; row < labirinth.GetLength(0); row++)
            {
                for (int col = 0; col < labirinth.GetLength(1); col++)
                {
                    if (labirinth[row, col] == StartingCell)
                    {
                        Cell startingCell = new Cell() 
                        { 
                            Row = row,
                            Col = col,
                            Distance = 0,
                        };

                        return startingCell;
                    }
                }
            }

            return new Cell();
        }

        private static void PlaceUnreachableCells(string[,] labirinth)
        {
            for (int row = 0; row < labirinth.GetLength(0); row++)
            {
                for (int col = 0; col < labirinth.GetLength(1); col++)
                {
                    if (labirinth[row, col] == EmptyCell)
                    {
                        labirinth[row, col] = UnreachableCell;
                    }
                }
            }
        }
    }
}
