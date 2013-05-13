namespace SinksApplication
{
    using System;
    using System.Linq;
    using SinksCommonLibrary;

    public class Application
    {
        private static Figure[] figures;
        private static int[,] coordinates;

        public static void Main(string[] args)
        {
            ReadCommands();
            Placer placer = new Placer(figures, coordinates, 500);
            string locations = placer.GetPlacement();
            Console.Write(locations);
        }
  
        private static void ReadCommands()
        {
            //Console.SetIn(new System.IO.StreamReader("..\\..\\SampleInput\\Input4.txt"));
            int lines = int.Parse(Console.ReadLine());
            figures = new Figure[lines];
            coordinates = new int[lines, 2];

            for (int i = 0; i < lines; i++)
            {
                string inputCommand = Console.ReadLine();
                string[] tokens = inputCommand.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                figures[i] = GetFigure(tokens[0]);

                coordinates[i, 0] = int.Parse(tokens[1]);
                coordinates[i, 1] = int.Parse(tokens[2]);
            }
        }

        private static Figure GetFigure(string figureName)
        {
            switch (figureName)
            {
                case "ninetile": return new Ninetile();
                case "plus": return new Plus();
                case "hline": return new Hline();
                case "vline": return new Vline();
                case "angle-ur": return new AngleUR();
                case "angle-dr": return new AngleDR();
                case "angle-dl": return new AngleDL();
                case "angle-ul": return new AngleUL();
                default: throw new ArgumentException();
            }
        }
    }
}
