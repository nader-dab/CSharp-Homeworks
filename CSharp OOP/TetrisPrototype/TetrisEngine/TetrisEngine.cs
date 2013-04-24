namespace TetrisEngine
{
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using TetrisLibrary;
    using CommonLibrary;

    public static class TetrisEngine
    {
        private static int score = 0;
        private static bool runGame = true; 

        public static void RunEngine()
        {
            List<Figure> figures = new List<Figure>();
            GameField field = new GameField();
            Figure nextFig = GenerateRandomFigure(0, 3);
            while (runGame)
            {
                if (figures.Count == 0 || figures[figures.Count - 1].CanFall == false)
                {
                    figures.Add(nextFig); // TODO: Add random generation and addition of different class figutes
                    nextFig = GenerateRandomFigure(0, 3);
                }
                
                DrawGamefield.Information(score, nextFig);
                figures[figures.Count - 1].Fall();
                Controls.UpdatePosition(figures[figures.Count - 1], field, ref runGame);
                PlaceMovingFigure(figures[figures.Count - 1], field);
                DrawGamefield.Draw(field);
                RemoveLine(field);
                Thread.Sleep(350);
            }
        }

        private static void RemoveLine(GameField field)
        {
            for (int row = field.Field.GetLength(0) - 1; row >= 0; row--)
            {
                int wholeLine = 0;
                for (int col = 0; col < field.Field.GetLength(1); col++)
                {
                    if (field.Field[row, col] != 999 && field.Field[row, col] != 0)
                    {
                        wholeLine++;
                    }
                }

                if (wholeLine == field.Field.GetLength(1))
                {
                    Console.Beep();
                    score += 10;
                    for (int col = 0; col < field.Field.GetLength(1); col++)
                    {
                        field.Field[row, col] = 0;
                    }

                    Falldown(field, row);
                }
            }
        }

        private static void Falldown(GameField field, int clearedRow)
        {
            int[,] newField = new int[field.Field.GetLength(0), field.Field.GetLength(1)];
            for (int row = field.Field.GetLength(0) - 1; row > clearedRow; row--)
            {
                for (int col = 0; col < field.Field.GetLength(1); col++)
                {
                    newField[row, col] = field.Field[row, col];
                }
            }

            for (int row = clearedRow; row > 0; row--)
            {
                for (int col = 0; col < field.Field.GetLength(1); col++)
                {
                    newField[row, col] = field.Field[row - 1, col];
                }
            }

            field.Field = newField;
        }

        private static Figure GenerateRandomFigure(int x, int y)
        {
            int number = RandomNumber.Generate(1, 7);
            try
            {
                switch (number)
                {
                    case 1: return new FigureI(x, y);
                    case 2: return new FigureJ(x, y);
                    case 3: return new FigureL(x, y);
                    case 4: return new FigureO(x, y);
                    case 5: return new FigureS(x, y);
                    case 6: return new FigureT(x, y);
                    case 7: return new FigureZ(x, y);
                    default: throw new InvalidFigureException("Figure Number is out of the given range", number);
                }
            }
            catch (InvalidFigureException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return new FigureI(x, y);

        }

        private static void PlaceMovingFigure(Figure figure, GameField field)
        {
            ClearTop(field);

            for (int figureHeigth = 0; figureHeigth < figure.Form.GetLength(0); figureHeigth++)
            {
                for (int figureWidth = 0; figureWidth < figure.Form.GetLength(1); figureWidth++)
                {
                    if (figure.Form[figureHeigth, figureWidth] != 0)
                    {

                        if (figure.PositionX + figureHeigth + 1 > field.Field.GetLength(0) - 1 || field.Field[figure.PositionX + figureHeigth + 1, figure.PositionY + figureWidth] != 0)
                        {
                            figure.CanFall = false;
                            if (figure.PositionX + figureHeigth == 1 || figure.PositionX + figureHeigth == 2)
                            {
                                runGame = false;
                            }
                        }

                        if (figure.CanFall)
                        {
                            field.Field[figure.PositionX + figureHeigth, figure.PositionY + figureWidth] = 999;
                        }
                        else
                        {
                            // TODO: Think of a smarter way to avoid duplication
                            PlaceStaticFigure(figure, field);
                        }
                    }
                }
            }
        }

        private static void PlaceStaticFigure(Figure figure, GameField field)
        {
            for (int figureHeigth1 = figure.Form.GetLength(0) - 1; figureHeigth1 >= 0; figureHeigth1--)
            {
                for (int figureWidth1 = 0; figureWidth1 < figure.Form.GetLength(1); figureWidth1++)
                {
                    if (figure.Form[figureHeigth1, figureWidth1] != 0)
                    {
                        field.Field[figure.PositionX + figureHeigth1, figure.PositionY + figureWidth1] = figure.Form[figureHeigth1, figureWidth1];
                    }
                }
            }
        }

        private static void ClearTop(GameField field)
        {
            for (int row = 0; row < field.Field.GetLength(0); row++)
            {
                for (int col = 0; col < field.Field.GetLength(1); col++)
                {
                    if (field.Field[row, col] == 999)
                    {
                        field.Field[row, col] = 0;
                    }
                }
            }
        }
    }
}
