namespace _01.ShapeSurfaceCalculator
{
    using System;

    public class MainProgram
    {
        public static void Main(string[] args)
        {
            var shapes = new Shape[]
            {
                new Rectangle(5, 5),
                new Triagle(6, 5),
                new Rectangle(10, 4),
                new Circle(5),
                new Circle(10),
            };

            foreach (var figure in shapes)
            {
                Console.WriteLine("{0} Surface = {1:0.00}", figure, figure.CalculateSerface());
            }
        }
    }
}