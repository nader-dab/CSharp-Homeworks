using System;
using System.Text;
using System.Globalization;
using System.Threading;

class QuadraticEquation
{
    static float EnterNumber(char variableName)
    {
        while (true)
        {
            float floatNumber;
            Console.Write("Please enter value for {0}: ", variableName);
            if (float.TryParse(Console.ReadLine(), out floatNumber))
            {
                return floatNumber;
            }
        }
    }

    static void Main()
    {   
        //To display the superscripped '2' of the quadratic equation.
        Console.OutputEncoding = Encoding.UTF8;
        //For entering floating point values on different cultures.
        Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
        Console.Title = "ax\u00B2 + bx + c = 0";
        Console.WriteLine("This program solves the following quadratic equation: ax\u00B2 + bx + c = 0");
        Console.WriteLine();
        float a = EnterNumber('a');
        float b = EnterNumber('b');
        float c = EnterNumber('c');
        float D = 0;
        
        if ((a != 0) && (b != 0))
        {
            D = (b * b) - (4 * a * c);

            if (D > 0)
            {
                float x1 = ((-b) + (float)Math.Sqrt(D)) / (2 * a);
                float x2 = ((-b) - (float)Math.Sqrt(D)) / (2 * a);
                Console.WriteLine("x1 = {0}; x2 = {1};", x1, x2);   
            }
            else if (D == 0)
            {
                float x = (-b) / (2 * a);
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
                Console.WriteLine("x = 0;");
            }
            else if (c < 0)
            {
                float x1 = (float)Math.Sqrt(Math.Abs(c)) / (float)Math.Sqrt(a);
                float x2 = (float)(-Math.Sqrt(Math.Abs(c))) / (float)Math.Sqrt(a);
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

