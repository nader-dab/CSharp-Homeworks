namespace Crawler
{
    using System;

    public static class ColorConsole
    {
        public static void Write(string input, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.Write(input);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}