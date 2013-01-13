using System;

class CheckIfPointIsInCircle
{
    static void Main()
    {
        Console.WriteLine("Please enter x coordinate.");
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter y coordinate.");
        int y = int.Parse(Console.ReadLine());
        Console.WriteLine(Math.Sqrt((x*x)+(y*y))<=5?
            "The point is located inside the circle K(0,5)":
            "The point is located outside the circle K(0,5)");
    }
}

