namespace Snake
{
    using System;
    using System.Linq;
    using System.Threading;

    public class Game
    {
        private const int ConsoleWidth = 40;
        private const int ConsoleHeight = 20;
        private const int ThreadSpeed = 200;
        private static Snake snake = new Snake(5, 5, Direction.Right, 5);
        private static bool runGame = true;

        public static void Main(string[] args)
        {
            Console.WindowWidth = ConsoleWidth;
            Console.WindowHeight = ConsoleHeight;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;
            Console.CursorVisible = false;

            KeyboardControls keyboard = new KeyboardControls();
            keyboard.OnLeftPress += HandleOnLeftPress;
            keyboard.OnRightPress += HandleOnRightPress;
            keyboard.OnUpPress += HandleOnUpPress;
            keyboard.OnDownPress += HandleOnDownPress;
            keyboard.OnEscape += HandleOnEscape;

            bool placeFood = false;
            Food food = new Food(RandomNumber.Generate(0, ConsoleWidth), RandomNumber.Generate(0, ConsoleHeight), '+');

            while (runGame)
            {
                Console.Clear();
                keyboard.ProcessInput();
                snake.Draw();
                snake.Update();

                food.Draw();
                if (placeFood)
                {
                    food = new Food(RandomNumber.Generate(0, ConsoleWidth), RandomNumber.Generate(0, ConsoleHeight), '+');
                    placeFood = false;
                }

                if (food.Position.X == snake.Body[0].Position.X && food.Position.Y == snake.Body[0].Position.Y)
                {
                    Console.Beep();
                    snake.AddBodyPart();
                    placeFood = true;
                }

                if (snake.Body[0].Position.X < 0 || 
                    snake.Body[0].Position.X >= ConsoleWidth || 
                    snake.Body[0].Position.Y < 0 || 
                    snake.Body[0].Position.Y >= ConsoleHeight)
                {
                    runGame = false;
                }

                for (int i = 1; i < snake.Body.Count; i++)
                {
                    if (snake.Body[0].Position.X == snake.Body[i].Position.X && snake.Body[0].Position.Y == snake.Body[i].Position.Y)
                    {
                        runGame = false;
                        break;
                    }
                }

                Thread.Sleep(ThreadSpeed);
            }

            Console.WriteLine("Thanks for playing");
        }

        private static void HandleOnEscape(object sender, EventArgs e)
        {
            runGame = false;
        }

        private static void HandleOnDownPress(object s, EventArgs e)
        {
            if (snake.Direction != Direction.Up)
            {
                snake.Direction = Direction.Down;
            }
        }

        private static void HandleOnUpPress(object s, EventArgs e)
        {
            if (snake.Direction != Direction.Down)
            {
                snake.Direction = Direction.Up;
            }
        }

        private static void HandleOnRightPress(object s, EventArgs e)
        {
            if (snake.Direction != Direction.Left)
            {
                snake.Direction = Direction.Right;
            }
        }

        private static void HandleOnLeftPress(object s, EventArgs e)
        {
            if (snake.Direction != Direction.Right)
            {
                snake.Direction = Direction.Left;
            }
        }
    }
}
