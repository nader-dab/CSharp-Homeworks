using System;
using System.Text;
using System.Globalization;
using System.Threading;

class QuadraticEquation
{
    static void Main()
    {   
        //Used to properly display the superscripped '2' of the quadratic equation.
        Console.OutputEncoding = Encoding.UTF8;
        //Used to ensure correct funcionality when entering floating point values on different cultures.
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        //Used to set the title of the console window.
        Console.Title = "ax\u00B2 + bx + c = 0";
        float a = 0;
        float b = 0;
        float c = 0;
        float D = 0;
        Console.WriteLine("This program solves the following quadratic equation: ax\u00B2 + bx + c = 0");
        //An infinite loop for entering propper value. If the value of the input variable is a correct
        //float number it will be parsed successfully and the break will exit the loop.  
        while (true)
        {
            Console.Write("Please enter value for a: ");
            if (float.TryParse(Console.ReadLine(), out a))
            {
                break;
            }
        }
        while (true)
        {
            Console.Write("Please enter value for b: ");
            if (float.TryParse(Console.ReadLine(), out b))
            {
                break;
            }
        }
        while (true)
        {
            Console.Write("Please enter value for c: ");
            if (float.TryParse(Console.ReadLine(), out c))
            {
                break;
            }
        }
        //If conditions used to check variuos possible inputs for solving a 
        //quadratic equation.
        if ((a != 0) && (b != 0))
        {
            D = (b * b) - (4 * a * c);

            if (D > 0)
            {
                float x1 = ((-b) + (float)Math.Sqrt(D)) / (2 * a);
                float x2 = ((-b) - (float)Math.Sqrt(D)) / (2 * a);
                Console.WriteLine("The roots of the euation are:");
                Console.WriteLine("x1 = {0}; x2 = {1};", x1, x2);
            }
            else if (D == 0)
            {
                float x = (-b) / (2 * a);
                Console.WriteLine("The root of the equation is:");
                Console.WriteLine("x = {0}", x);
            }
            else if (D < 0)
            {
                Console.WriteLine("The equation cannot be solved.");
            }
        }

        else if ((a ==  0) && (b != 0))
        {
            float x = (-c) / b;
            Console.WriteLine("The root of the equation is:");
            Console.WriteLine("x = {0}", x);
        }
        else if ((a != 0) && (b == 0))
        {
            if (c > 0)
            {
                Console.WriteLine("The equation cannot be solved.");
            }
            else if (c == 0)
            {
                Console.WriteLine("The root of the equation is:");
                Console.WriteLine("x = 0;");
            }
            else if (c < 0)
            {
                float x1 = (float)Math.Sqrt(Math.Abs(c)) / (float)Math.Sqrt(a);
                float x2 = (float)(-Math.Sqrt(Math.Abs(c))) / (float)Math.Sqrt(a);
                Console.WriteLine("The roots of the euation are:");
                Console.WriteLine("x1 = {0}; x2 = {1};", x1, x2);
            }
        }
        else if ((a == 0) && (b == 0) && (c !=0))
        {
            Console.WriteLine("The equation cannot be solved.");
        }
        else if ((a == 0) && (b == 0) && (c == 0))
        {
            Console.WriteLine("The equation cannot be solved.");
        }
    }
}

