using System;

class CalcNAndXSum
{
    static int EnterNumber(char name, int lowerLimit)
    {
        int number;
        string input;
        do
        {
            Console.Write("Please enter {0}: ", name);
            input = Console.ReadLine();
        } 
        while (!int.TryParse(input, out number) || ((name == 'N') && (number <= lowerLimit)) || (number == 0));
        return number;
    }
    static void Main()
    {
        int n = EnterNumber('N', 1);
        int x = EnterNumber('X', 0);
        double nFactorial = 1;
        double xToPowerN = 1;
        double s = 1;

        for (int i = 1; i <= n; i++)
        {
            nFactorial*= i;
            xToPowerN = Math.Pow(x, i);
            s += nFactorial / xToPowerN;
        }
        //Console.WriteLine(nFactorial);
        //Console.WriteLine(xToPowerN);
        Console.WriteLine(s);
    }
}

