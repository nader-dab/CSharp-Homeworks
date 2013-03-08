namespace MatrixLibrary
{
    using System;
    using System.Text;

    public class Matrix<T>
        where T : struct, IComparable<T>
    {
        private T[,] innerMatrix;

        public Matrix() : this(0, 0) 
        { 
        }

        public Matrix(int row, int col)
        {
            if (row < 0 || col < 0)
            {
                throw new ArgumentException("Matrix dimentions must be a non negative value.");
            }

            this.InnerMatrix = new T[row, col];
        }

        private T[,] InnerMatrix
        {
            get
            {
                return this.innerMatrix;
            }

            set
            {
                this.innerMatrix = value;
            }
        }

        public T this[int row, int col]
        {
            get
            {
                if (row < 0 || col < 0 || row > this.InnerMatrix.GetLength(0) - 1 || col > this.InnerMatrix.GetLength(1) - 1)
                {
                    throw new ArgumentOutOfRangeException("Index was out of range. Must be within the bounds of the matrix");
                }

                return this.InnerMatrix[row, col];
            }

            set
            {
                if (row < 0 || col < 0 || row > this.InnerMatrix.GetLength(0) - 1 || col > this.InnerMatrix.GetLength(1) - 1)
                {
                    throw new ArgumentOutOfRangeException("Index was out of range. Must be within the bounds of the matrix");
                }

                this.InnerMatrix[row, col] = value;
            }
        }

        public static Matrix<T> operator +(Matrix<T> matrixOne, Matrix<T> matrixTwo)
        {
            if (matrixOne.GetLength(0) != matrixTwo.GetLength(0)
                || matrixOne.GetLength(1) != matrixTwo.GetLength(1))
            {
                throw new ArgumentException("Connot add matrices of different size.");
            }

            Matrix<T> matrixResult = new Matrix<T>(matrixOne.GetLength(0), matrixOne.GetLength(1));
            for (int row = 0; row < matrixOne.GetLength(0); row++)
            {
                for (int col = 0; col < matrixOne.GetLength(1); col++)
                {
                    matrixResult[row, col] = (T)Convert.ChangeType(Convert.ToDouble(matrixOne[row, col]) + Convert.ToDouble(matrixTwo[row, col]), typeof(T));
                }
            }

            return matrixResult;
        }

        public static Matrix<T> operator -(Matrix<T> matrixOne, Matrix<T> matrixTwo)
        {
            if (matrixOne.GetLength(0) != matrixTwo.GetLength(0)
                || matrixOne.GetLength(1) != matrixTwo.GetLength(1))
            {
                throw new ArgumentException("Connot substract matrices of different size.");
            }

            Matrix<T> matrixResult = new Matrix<T>(matrixOne.GetLength(0), matrixOne.GetLength(1));
            for (int row = 0; row < matrixOne.GetLength(0); row++)
            {
                for (int col = 0; col < matrixOne.GetLength(1); col++)
                {
                    matrixResult[row, col] = (T)Convert.ChangeType(Convert.ToDouble(matrixOne[row, col]) - Convert.ToDouble(matrixTwo[row, col]), typeof(T));
                }
            }

            return matrixResult;
        }

        public static Matrix<T> operator *(Matrix<T> matrixOne, Matrix<T> matrixTwo)
        {
            if (matrixOne.GetLength(0) != matrixTwo.GetLength(0)
                || matrixOne.GetLength(1) != matrixTwo.GetLength(1))
            {
                throw new ArgumentException("Connot multiply matrices of different size.");
            }

            Matrix<T> matrixResult = new Matrix<T>(matrixOne.GetLength(0), matrixOne.GetLength(1));
            for (int row = 0; row < matrixOne.GetLength(0); row++)
            {
                for (int col = 0; col < matrixOne.GetLength(1); col++)
                {
                    double sum = 0;
                    for (int index = 0; index < matrixOne.GetLength(1); index++)
                    {
                        sum = sum + (Convert.ToDouble(matrixOne[row, col]) * Convert.ToDouble(matrixTwo[row, col]));
                    }

                    matrixResult[row, col] = (T)Convert.ChangeType(sum, typeof(T));
                }
            }

            return matrixResult;
        }

        public static bool operator true(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (Convert.ToDouble(matrix[row, col]) != 0)
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator false(Matrix<T> matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    if (Convert.ToDouble(matrix[row, col]) != 0)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public int GetLength(int dimension)
        {
            return this.innerMatrix.GetLength(dimension);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int row = 0; row < this.InnerMatrix.GetLength(0); row++)
            {
                for (int col = 0; col < this.InnerMatrix.GetLength(1); col++)
                {
                    sb.Append(this.InnerMatrix[row, col] + " ");
                }

                if (row != this.InnerMatrix.GetLength(0) - 1)
                {
                    sb.Append("\n");
                }
            }

            return sb.ToString();
        }
    }
}
