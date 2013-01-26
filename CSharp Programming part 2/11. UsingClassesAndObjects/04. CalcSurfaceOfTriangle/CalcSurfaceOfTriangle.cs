using System;

class CalcSurfaceOfTriangle
{
    static void Main(string[] args)
    {
        Console.WriteLine("Select a way to calculate surface of triangle.");
        Console.WriteLine("1) By side and altitude.");
        Console.WriteLine("2) By three sides.");
        Console.WriteLine("3) By two sides and an angle between them.");
        int choice;
        int.TryParse(Console.ReadLine(), out choice);
        Console.Clear();
        switch (choice)
        {
            case 1: CalcBySideAndAltitude(); break;
            case 2: CalcByThreeSides(); break;
            case 3: CalcByTwoSidesAndAngle(); break;
            default: Console.WriteLine("Wrong input!");
                break;
        }
    }

    private static void CalcBySideAndAltitude()
    {
        Console.Write("Please enter side : ");
        double side = double.Parse(Console.ReadLine());
        Console.Write("Please enter altitude: ");
        double altitude = double.Parse(Console.ReadLine());
        double surface = side * altitude / 2;
        Console.WriteLine("The surface of the triangle is: {0:0.000}", surface);
    }

    private static void CalcByThreeSides()
    {
        Console.Write("Please enter side a: ");
        double sideA = double.Parse(Console.ReadLine());
        Console.Write("Please enter side b: ");
        double sideB = double.Parse(Console.ReadLine());
        Console.Write("Please enter side c: ");
        double sideC = double.Parse(Console.ReadLine());
        double semiPerimeter = (sideA + sideB + sideC)/2;
        double surface = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
        Console.WriteLine("The surface of the triangle is: {0:0.000}", surface);
    }

    private static void CalcByTwoSidesAndAngle()
    {
        Console.Write("Please enter side a: ");
        double sideA = double.Parse(Console.ReadLine());
        Console.Write("Please enter side b: ");
        double sideB = double.Parse(Console.ReadLine());
        Console.Write("Please enter angle: ");
        double angle = double.Parse(Console.ReadLine());
        double surface = sideA * sideB * Math.Sin(angle * Math.PI / 180) / 2;
        Console.WriteLine("The surface of the triangle is: {0:0.000}", surface);
    }
   
}