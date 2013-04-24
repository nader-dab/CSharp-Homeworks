namespace TetrisProgram
{
    using System;
    using TetrisEngine;
    using CommonLibrary;

    class Program
    {
        static GameState currentState = GameState.Menu;
        static void Main(string[] args)
        {
            Console.WindowHeight = 21;
            Console.WindowWidth = 40;
            Console.BufferHeight = Console.WindowHeight;
            Console.BufferWidth = Console.WindowWidth;

            while (true)
            {
                switch (currentState)
                {
                    case GameState.Menu:
                        GameMenu();
                        currentState = GameState.PlayGame;
                        break;
                    case GameState.PlayGame:
                        TetrisEngine.RunEngine();
                        currentState = GameState.GameOver;
                        break;
                    case GameState.GameOver:
                        GameOverScreen();
                        return;
                    default:
                        break;
                }
            }
        }

        private static void GameOverScreen()
        {
            Console.Clear();
            Console.SetCursorPosition(15, 10);
            ColorConsole.WriteLine("Game Over", ConsoleColor.Red);
            Console.ReadKey();
        }

        private static void GameMenu()
        {
            ColorConsole.WriteLine("Tetris Game", ConsoleColor.Green);
            ColorConsole.WriteLine("Controls", ConsoleColor.Yellow);
            Console.WriteLine("<- Move Figure Left");
            Console.WriteLine("-> Move Figure Rigth");
            Console.WriteLine("[S] Rotate Figure");
            Console.WriteLine("[Escape] Quit");
            Console.WriteLine("Press any key to begin");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
