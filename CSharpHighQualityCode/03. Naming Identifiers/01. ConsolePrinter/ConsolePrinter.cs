using System;

class ConsolePrinter
{
    class Converter
    {
        public void PrintBoolAsString(bool value)
        {
            string boolsAsString = value.ToString();
            Console.WriteLine(boolsAsString);
        }
    }

    public static void Main()
    {
        ConsolePrinter.Converter converter =
            new ConsolePrinter.Converter();
        converter.PrintBoolAsString(true);
    }
}
