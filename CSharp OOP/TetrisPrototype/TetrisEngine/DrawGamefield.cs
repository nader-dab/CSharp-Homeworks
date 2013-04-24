using CommonLibrary;
using System;
using TetrisLibrary;

namespace TetrisEngine
{
    public class DrawGamefield
    {
        public static void Draw(GameField field)
        {
            Console.SetCursorPosition(0, 0);

            for (int row = 0; row < field.Field.GetLength(0); row++)
            {
                for (int col = 0; col < field.Field.GetLength(1); col++)
                {
                    if (field.Field[row, col] != 0)
                    {
                        int colorValue = field.Field[row, col];
                        ColorConsole.Write("█", GetColor(colorValue));
                    }
                    else
                    {
                        ColorConsole.Write("*");
                    }
                }
                ColorConsole.Write("\n");
            }
        }

        public static void Information(int score, Figure nextFig)
        {
            Console.SetCursorPosition(15, 0);
            ColorConsole.Write("SCORE: " + score, ConsoleColor.Green);
            Console.SetCursorPosition(15, 1);
            ColorConsole.Write("NEXT FIGURE: ", ConsoleColor.Green);
            PrintNextFigure(nextFig);
            Console.WriteLine();
        }

        private static void PrintNextFigure(Figure nextFig)
        {
            for (int row = 0; row < 4; row++)
            {
                for (int col = 0; col < 4; col++)
                {
                    Console.SetCursorPosition(15 + col, 3 + row);
                    Console.Write(" ");
                }
            }

            for (int row = 0; row < nextFig.Form.GetLength(0); row++)
            {
                for (int col = 0; col < nextFig.Form.GetLength(1); col++)
                {
                    Console.SetCursorPosition(15 + col, 3 + row);
                    if (nextFig.Form[row, col] != 0)
                    {
                        ColorConsole.Write("█", GetColor(nextFig.Form[row, col]));
                    }
                    else
                    {
                        ColorConsole.Write(" ");
                    }
                }
            }
        }

        private static ConsoleColor GetColor(int number)
        {
            try
            {
                switch (number)
                {
                    case 0: return ConsoleColor.Gray;
                    case 1: return ConsoleColor.Red;
                    case 2: return ConsoleColor.Magenta;
                    case 3: return ConsoleColor.Yellow;
                    case 4: return ConsoleColor.Cyan;
                    case 5: return ConsoleColor.Blue;
                    case 6: return ConsoleColor.Gray;
                    case 7: return ConsoleColor.Green;
                    case 999: return ConsoleColor.White;
                    default: throw new InvalidColorException("Color Number is out of given range", number);
                }
            }
            catch (InvalidColorException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return ConsoleColor.White;
        }
    }
}
