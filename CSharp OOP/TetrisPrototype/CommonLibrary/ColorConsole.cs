/// Design Pattern Adapter / Wrapper / Translator. http://en.wikipedia.org/wiki/Adapter_pattern
/// 
namespace CommonLibrary
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

        public static void WriteLine(string input, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(input);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}