using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07.FindAllPathsBetweenTwoCells
{
    class FindAllPathsBetweenTwoCells
    {
        static char[,] matrix = new char[,]
        {
            {' ', ' ', ' ', '*', ' ' },
            {'*', '*', ' ', '*', ' ' },
            {' ', ' ', ' ', ' ', ' ' },
            {' ', '*', '*', '*', ' ' },
            {' ', ' ', ' ', ' ', 'e' },
        };

        static List<char> path = new List<char>();

        static void Main(string[] args)
        {
            int startingRow = 0;
            int startignCol = 0;

            FindAllPaths(startingRow, startignCol, 'S');
        }

        private static void FindAllPaths(int row, int col, char direction)
        {

            if (row < 0 || col < 0 ||row >= matrix.GetLength(0) || col >= matrix.GetLength(1))
            {
                return;
            }
            if (matrix[row,col] == '*')
            {
                return;
            }
         
            if (matrix[row, col] == 'e')
            {
                path.Add(direction);
                Console.WriteLine(string.Join("->", path));
                path.RemoveAt(path.Count - 1);
                return;
            }
            
            matrix[row, col] = '*';
            path.Add(direction);
            FindAllPaths(row, col + 1, 'R');
            FindAllPaths(row + 1, col, 'D');
            FindAllPaths(row, col - 1, 'L');
            FindAllPaths(row - 1, col, 'U');
            matrix[row, col] = ' ';
            path.RemoveAt(path.Count - 1);
        
        }
    }
}
