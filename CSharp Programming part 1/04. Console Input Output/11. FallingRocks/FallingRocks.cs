using System;
using System.Threading;
using System.Collections.Generic;

class FallingRocks
{
    struct Rock
    {
        public int x;
        public int y;
        public char symbol;
        public ConsoleColor color;
    }
    struct Ship
    {
        public int x;
        public int y;
        public string form;
        public ConsoleColor color;
    }
    static void DrawPlayer()
    {
        Console.SetCursorPosition(player.x, player.y);
        Console.ForegroundColor = player.color;
        Console.WriteLine(player.form);
    }
    static void MovePlayer()
    {
        if (Console.KeyAvailable)
        {
            ConsoleKeyInfo pressedKey = Console.ReadKey();
            while (Console.KeyAvailable)
            {
                Console.ReadKey();
            }
            if (pressedKey.Key == ConsoleKey.LeftArrow && player.x > 0)
            {
                player.x--;
            }
            else if (pressedKey.Key == ConsoleKey.RightArrow && player.x < Console.WindowWidth - player.form.Length - 1)
            {
                player.x++;
            }
        }
    }
    static ConsoleColor SetRandomColor()
    {
        ConsoleColor randomColor = Console.ForegroundColor;
        switch (rand.Next(0, 6))
        {
            case 1: randomColor = ConsoleColor.Cyan; break;
            case 2: randomColor = ConsoleColor.Red; break;
            case 3: randomColor = ConsoleColor.Yellow; break;
            case 4: randomColor = ConsoleColor.Green; break;
            case 5: randomColor = ConsoleColor.White; break;
            default: randomColor = ConsoleColor.Gray; break;
        }
        return randomColor;
    }

    static void GenerateObstacle()
    {
        for (int i = 0; i < Console.WindowWidth; i++)
        {
            int chance = rand.Next(0, 75);
            if (rand.Next(0, 100) <= 5)
            {
                obstacle.x = rand.Next(0, Console.WindowWidth - 2);
                obstacle.y = 0;
                obstacle.symbol = rockType[rand.Next(0, rockType.Length)];
                obstacle.color = SetRandomColor();
                if (chance < 35)
                {
                    ObstacleRow.Add(obstacle);
                }
                else if (chance >= 35 && chance < 70)
                {
                    if (i < Console.WindowWidth - 2)
                    {
                        ObstacleRow.Add(obstacle);
                        obstacle.x++;
                        ObstacleRow.Add(obstacle);
                        i++;
                    }
                }
                else if (chance >= 70 && chance < 100)
                {
                    if (i < Console.WindowWidth - 3)
                    {
                        ObstacleRow.Add(obstacle);
                        obstacle.x++;
                        ObstacleRow.Add(obstacle);
                        obstacle.x++;
                        ObstacleRow.Add(obstacle);
                        i = i + 2;
                    }

                }
            }
        }

    }
    static void MoveObstacle()
    {
        List<Rock> updateObstacles = new List<Rock>();
        int sameRowEntries = 0;
        foreach (var item in ObstacleRow)
        {
            Rock oldRock = item;
            oldRock.y++;
            if (oldRock.y == Console.WindowHeight - 1)
            {
                ObstacleRow.Remove(oldRock);
            }
            else
            {
                updateObstacles.Add(oldRock);
            }

            if (oldRock.y == Console.WindowHeight - 2 && oldRock.x >= player.x && oldRock.x <= player.x + player.form.Length - 1)
            {
                Console.SetCursorPosition(Console.WindowWidth / 2 - 5, Console.WindowHeight / 2);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You Got Hit!!!");
                Console.ReadKey();
                lives--;

            }
            else if (oldRock.y == Console.WindowHeight - 1 && sameRowEntries != oldRock.y)
            {
                score++;
                sameRowEntries = oldRock.y;
            }
        }
        ObstacleRow = updateObstacles;
    }

    static void DrawObstacle()
    {
        foreach (var item in ObstacleRow)
        {
            Console.SetCursorPosition(item.x, item.y);
            Console.ForegroundColor = item.color;
            Console.WriteLine(item.symbol);
        }

    }
    static void PrintOnPosition(int x, int y, string c, ConsoleColor color)
    {
        Console.SetCursorPosition(x, y);
        Console.ForegroundColor = color;
        Console.WriteLine(c);
    }
    static Ship player = new Ship();
    static Rock obstacle = new Rock();
    static char[] rockType = { '^', '@', '*', '&', '+', '%', '$', '#', '!', '.', ';', '@' };
    static Random rand = new Random();
    static List<Rock> ObstacleRow = new List<Rock>();
    static int lives = 10;
    static int score = 0;

    static void Main()
    {
        Console.BufferHeight = Console.WindowHeight;
        Console.BufferWidth = Console.WindowWidth;
        player.x = Console.WindowWidth / 2;
        player.y = Console.WindowHeight - 1;
        player.color = ConsoleColor.White;
        player.form = "(0)";
        while (true)
        {
            Console.Clear();
            DrawPlayer();

            int chance = rand.Next(0, 100);
            if (chance < 30)
            {
                GenerateObstacle();
            }
            DrawObstacle();
            MoveObstacle();
            MovePlayer();
            PrintOnPosition(Console.WindowWidth - 25, 0, "Lives = " + lives + " Score = " + score, Console.ForegroundColor = ConsoleColor.Yellow);
            if (lives == 0)
            {
                break;
            }
            Thread.Sleep(150);
        }
        Console.SetCursorPosition(Console.WindowWidth / 2 - 10, Console.WindowHeight / 2);
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("       GAME OVER        ");
    }
}

