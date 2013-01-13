using System;

    class Program
    {
        static void Main()
        {
            Console.WriteLine("Please enter rectangle witdth");
            int width = int.Parse(Console.ReadLine());
            Console.WriteLine("Please enter rectangle height");
            int height = int.Parse(Console.ReadLine());
            int area = width * height;
            Console.WriteLine("The are of the rectangle is {0} x {1} = {2}", width, height, area);
        }
    }

