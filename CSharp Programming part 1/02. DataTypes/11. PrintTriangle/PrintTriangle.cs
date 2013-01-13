using System;
using System.Text;
class PrintTriangle
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        char symbol = '\u00A9';
        Console.WriteLine("Enter height of the triangle");
        int height = int.Parse(Console.ReadLine());
        for (int i = 0; i < height; i++)
        {
            if (i==0)
            {
                string space = new string (' ', height - 1);
                Console.Write(space);
                Console.Write(symbol);
                Console.WriteLine();
            }
            else if (i == height - 1)
            {
                Console.WriteLine(new string(symbol, height * 2 - 1));

            }
            else
            {
                string space = new string(' ', height - i - 1);
                string fill = new string(' ', 2 * i - 1);
                Console.Write(space);
                Console.Write(symbol);
                Console.Write(fill);
                Console.Write(symbol);
                Console.WriteLine();
            }   
        }
    }
}

