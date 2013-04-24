using System;
using TetrisLibrary;

namespace TetrisEngine
{
    class Controls
    {
        private static GameCommand command = GameCommand.none;

        public static void UpdatePosition(Figure figure, GameField field, ref bool runGame)
        {
            KeyboardControls keyboard = new KeyboardControls();
            keyboard.OnLeftPressed += HandleOnLeftPressed;
            keyboard.OnRightPressed += HandleOnRightPressed;
            keyboard.OnRotatePressed += HandleOnRotatePressed;
            keyboard.OnEscapePressed += HandleOnEscapePressed;
            keyboard.ProcessInput();
            switch (command)
            {
                case GameCommand.none:
                    break;
                case GameCommand.left:
                    if (figure.PositionY > 0)
                    {
                        figure.MoveLeft();
                    }
                    break;
                case GameCommand.right:
                    if (figure.PositionY + figure.Form.GetLength(1) < field.Field.GetLength(1))
                    {
                        figure.MoveRight();
                    }
                    break;
                case GameCommand.rotate:
                    if ((figure.PositionX + figure.Form.GetLength(1) - 1 < field.Field.GetLength(0))
                     && (figure.PositionY + figure.Form.GetLength(0) - 1 < field.Field.GetLength(1)))
                    {
                        figure.RotateR();
                    }
                    break;
                case GameCommand.escape:
                    runGame = false;
                    break;
                default:
                    break;
            }
            command = GameCommand.none;

        }

        private static void HandleOnLeftPressed(object s, EventArgs e)
        {
            command = GameCommand.left;
        }

        private static void HandleOnRightPressed(object s, EventArgs e)
        {
            command = GameCommand.right;
        }

        private static void HandleOnRotatePressed(object s, EventArgs e)
        {
            command = GameCommand.rotate;
        }

        private static void HandleOnEscapePressed(object s, EventArgs e)
        {
            command = GameCommand.escape;
        }
    }
}
