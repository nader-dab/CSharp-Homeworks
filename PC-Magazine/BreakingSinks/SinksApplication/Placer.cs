namespace SinksApplication
{
    using System;
    using System.Text;
    using SinksCommonLibrary;

    public class Placer
    {
        public Placer(Figure[] figures, int[,] coordinates, int size)
        {
            this.Figures = figures;
            this.Coordinates = coordinates;
            this.Field = new int[size, size];
        }

        public Figure[] Figures { get; private set; }

        public int[,] Coordinates { get; private set; }

        public int[,] Field { get; private set; }

        public string GetPlacement()
        {
            StringBuilder sb = new StringBuilder();
            int totalFigures = this.Figures.Length;
            int totalDistance = 0;
            for (int i = 0; i < totalFigures; i++)
            {
                int tryRow = this.Coordinates[i, 0];
                int tryCol = this.Coordinates[i, 1];
                int tryDistance = 0;
               
                this.FindShortestDistanceToPlaceFigure(this.Figures[i], ref tryRow, ref tryCol, ref tryDistance);

                totalDistance += tryDistance;
                sb.AppendFormat("{0} {1}{2}", tryRow, tryCol, Environment.NewLine);
            }

            //sb.AppendFormat("total distance {0}{1}", totalDistance, Environment.NewLine);

            return sb.ToString();
        }

        private void FindShortestDistanceToPlaceFigure(Figure figure, ref int tryRow, ref int tryCol, ref int tryDistance)
        {
            if (this.PlaceFiture(figure, tryRow, tryCol))
            {
                return;
            }

            while (true)
            {
                tryDistance++;

                tryRow += tryDistance;
                if (this.PlaceFiture(figure, tryRow, tryCol))
                {
                    return;
                }

                for (int i = 0; i < tryDistance; i++)
                {
                    tryCol += 1;
                    tryRow -= 1;

                    if (this.PlaceFiture(figure, tryRow, tryCol))
                    {
                        return;
                    }
                }

                for (int i = 0; i < tryDistance; i++)
                {
                    tryCol -= 1;
                    tryRow -= 1;

                    if (this.PlaceFiture(figure, tryRow, tryCol))
                    {
                        return;
                    }
                }

                for (int i = 0; i < tryDistance; i++)
                {
                    tryCol -= 1;
                    tryRow += 1;

                    if (this.PlaceFiture(figure, tryRow, tryCol))
                    {
                        return;
                    }
                }

                for (int i = 0; i < tryDistance; i++)
                {
                    tryCol += 1;
                    tryRow += 1;

                    if (this.PlaceFiture(figure, tryRow, tryCol))
                    {
                        return;
                    }
                }

                tryRow -= tryDistance;
            }
        }

        private bool PlaceFiture(Figure figure, int row, int col)
        {
            row -= figure.Center.Row;
            col -= figure.Center.Col;

            for (int figureRow = 0; figureRow < figure.Form.GetLength(0); figureRow++)
            {
                for (int figureCol = 0; figureCol < figure.Form.GetLength(1); figureCol++)
                {
                    bool figureCondition = figure.Form[figureRow, figureCol] != 0;

                    if (figureCondition)
                    {
                        bool fieldRowCondition = row + figureRow < 0 || row + figureCol > this.Field.GetLength(0) - 1;
                        bool fieldColCondition = col + figureCol < 0 || col + figureCol > this.Field.GetLength(1) - 1;

                        if (fieldRowCondition || fieldColCondition || this.Field[this.Field.GetLength(0) - 1 - (row + figureRow), col + figureCol] != 0)
                        {
                            return false;
                        }
                    }
                }
            }

            for (int fieldRow = row; fieldRow < row + figure.Form.GetLength(0); fieldRow++)
            {
                for (int fieldCol = col; fieldCol < col + figure.Form.GetLength(1); fieldCol++)
                {
                    if (figure.Form[fieldRow - row, fieldCol - col] != 0)
                    {
                        this.Field[this.Field.GetLength(0) - fieldRow - 1, fieldCol] = figure.Form[fieldRow - row, fieldCol - col];
                    }
                }
            }

            //this.PrintField();
            return true;
        }

        private void PrintField()
        {
            Console.WriteLine();
            for (int i = this.Field.GetLength(0) - 10; i < this.Field.GetLength(0); i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Console.Write(this.Field[i, j]);
                }

                Console.WriteLine();
            }
        }
    }
}
