namespace WalkInMatrix
{
    using System;

    public class WalkInMatrix
    {
        private int step = 1;

        public WalkInMatrix(int size)
        {
            this.Matrix = new int[size, size];

            int row = 0;
            int col = 0;

            do
            {
                this.MatrixWalk(this.Matrix, row, col);
                this.FindEmptyCell(this.Matrix, out row, out col);
            } 
            while (row != 0 && col != 0);
        }

        public int[,] Matrix { get; private set; }

        public void PrintMatrixToConsole()
        {
            for (int row = 0; row < this.Matrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.Matrix.GetLength(1); col++)
                {
                    Console.Write("{0,3}", this.Matrix[row, col]);
                }

                Console.WriteLine();
            }
        }

        private void ChangeDirection(ref int directionX, ref int directionY)
        {
            Directions possibleDirections = new Directions();

            int currentDirection = 0;

            for (int count = 0; count < possibleDirections.X.Length; count++)
            {
                if (possibleDirections.X[count] == directionX && possibleDirections.Y[count] == directionY)
                {
                    currentDirection = count;
                    break;
                }
            }

            if (currentDirection == possibleDirections.X.Length - 1)
            {
                directionX = possibleDirections.X[0];
                directionY = possibleDirections.Y[0];
                return;
            }

            directionX = possibleDirections.X[currentDirection + 1];
            directionY = possibleDirections.Y[currentDirection + 1];
        }

        private bool CheckDirection(int[,] matrix, int directionX, int directionY)
        {
            Directions possibleDirections = new Directions();

            for (int i = 0; i < possibleDirections.X.Length; i++)
            {
                if (this.IsLessThanZeroAndGreaterThanLimit(directionX + possibleDirections.X[i], matrix.GetLength(0)))
                {
                    possibleDirections.X[i] = 0;
                }

                if (this.IsLessThanZeroAndGreaterThanLimit(directionY + possibleDirections.Y[i], matrix.GetLength(1)))
                {
                    possibleDirections.Y[i] = 0;
                }
            }

            for (int i = 0; i < possibleDirections.X.Length; i++)
            {
                if (matrix[directionX + possibleDirections.X[i], directionY + possibleDirections.Y[i]] == 0)
                {
                    return true;
                }
            }

            return false;
        }

        private void FindEmptyCell(int[,] matrix, out int row, out int col)
        {
            row = 0;
            col = 0;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    if (matrix[i, j] == 0)
                    {
                        row = i;
                        col = j;
                        return;
                    }
                }
            }
        }

        private void MatrixWalk(int[,] matrix, int row, int col)
        {
            int curentDirectionX = 1;
            int currentDirectionY = 1;

            while (true)
            {
                matrix[row, col] = this.step;

                if (!this.CheckDirection(matrix, row, col))
                {
                    break;
                }

                while (this.IsCellTaken(matrix, row + curentDirectionX, col + currentDirectionY))
                {
                    this.ChangeDirection(ref curentDirectionX, ref currentDirectionY);
                }

                row += curentDirectionX;
                col += currentDirectionY;
                this.step++;
            }
        }

        private bool IsCellTaken(int[,] matrix, int row, int col)
        {
            bool result = this.IsCellOutsideMatrix(matrix, row, col) || matrix[row, col] != 0;
            return result;
        }

        private bool IsCellOutsideMatrix(int[,] matrix, int row, int col)
        {
            bool rowCondition = this.IsLessThanZeroAndGreaterThanLimit(row, matrix.GetLength(0));
            bool colCondition = this.IsLessThanZeroAndGreaterThanLimit(col, matrix.GetLength(1));
            bool result = rowCondition || colCondition;
            return result;
        }

        private bool IsLessThanZeroAndGreaterThanLimit(int value, int limit)
        {
            bool result = value < 0 || value >= limit;
            return result;
        }
    }
}
