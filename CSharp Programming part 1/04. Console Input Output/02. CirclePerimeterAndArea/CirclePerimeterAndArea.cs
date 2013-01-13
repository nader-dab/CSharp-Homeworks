using System;

class CirclePerimeterAndArea
{
    static void Main()
    {
        Console.Title = "Circle Calculator";
        Console.Write("Enter radius: ");
        float r;
        while (true)
        {
            if (float.TryParse(Console.ReadLine(), out r))
            {
                break;
            }
            Console.Write("Incorrect Input. Please enter a propper value:");
        }
        Console.WriteLine();
        Console.WriteLine("{0,-35} {1,15:0.000}", "The perimeter of the circle is: ", 2*Math.PI*r);
        Console.WriteLine("{0,-35} {1,15:0.000}", "The area of the circle is:", Math.PI*r*r);
    }
}

