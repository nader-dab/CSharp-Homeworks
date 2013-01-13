using System;


class PrintMinAndMax
{
    static int EnterNumber(string name)
    {
        string input;
        int number;
        do
        {
            Console.Write("Please enter number {0}: ", name);
            input = Console.ReadLine();
        }
        while (!int.TryParse(input, out number) || (number < 0));
        return number;
    }
    static void Main()
    {
        int min;
        int max;
        int n = EnterNumber("N");
        int[] value = new int[n];
        for (int i = 0;  i < n; i++)
        {
            value[i] = EnterNumber((i + 1).ToString());                   		         	
        }
        max = value[0];
        min = value[0];
        for (int i = 1; i < n; i++)
        {
            if (value[i] > max)
            {
                max = value[i];
            }
            if (value[i] < min)
            {
                min = value[i];
            }
        }
        Console.WriteLine("min = {0} max = {1}", min, max);
    }
}

