using System;

class CheckIfPointIsInCircleRect
{
    static void Main()
    {
        Console.WriteLine("Please enter x coordinate");
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine("Please enter y coordinate");
        int y = int.Parse(Console.ReadLine());
        Console.WriteLine((Math.Sqrt((x - 1) * (x - 1) + (y - 1) * (y - 1)) <= 3) ?
            "The point is whitin the circle K((1,1), 3)" :
            "The point is outside the circle K((1,1), 3)");
        Console.WriteLine((((x >= -1) && (x <= 5)) && ((y >= -1) && (y <= 1))) ?
            "The point is whitih the rectantle" :
            "The point is outside the rectangle");
    }
}

