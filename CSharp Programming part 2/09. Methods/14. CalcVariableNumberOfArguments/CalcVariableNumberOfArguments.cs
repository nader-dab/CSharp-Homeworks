using System;
using System.Collections.Generic;

public class CalcVariableNumberOfArguments
{
    public static void Main()
    {
        Console.Write("Enter the number of arguments: ");
        int n = int.Parse(Console.ReadLine());

        List<int> arguments = new List<int>();
        for (int index = 0; index < n; index++)
        {
            Console.Write("Enter element[{0}]: ", index);
            arguments.Add(int.Parse(Console.ReadLine()));
        }
        int min = FindMin(arguments);
        Console.WriteLine("The mininal element is: {0}", min);

        int max = FindMax(arguments);
        Console.WriteLine("The maximal element is: {0}", max);

        float avarage = CalcAvarage(arguments);
        Console.WriteLine("The avarage is: {0:0.000}", avarage);

        long product = CalcProduct(arguments);
        Console.WriteLine("The product is: {0}", product);
    }

    public static long CalcProduct(List<int> arguments)
    {
        long product = 1;
        foreach (var item in arguments)
        {
            product *= item;
        }
        return product;
    }

    public static float CalcAvarage(List<int> arguments)
    {
        long sum = 0;
        foreach (var item in arguments)
        {
            sum += item;
        }
        float avarage = (float)sum / arguments.Count;
        return avarage;
    }

    public static int FindMax(List<int> arguments)
    {
        int max = int.MinValue;
        foreach (var item in arguments)
        {
            if (item > max)
            {
                max = item;
            }
        }

        return max;
    }

    public static int FindMin(List<int> arguments)
    {
        int min = int.MaxValue;
        foreach (var item in arguments)
        {
            if (item < min)
            {
                min = item;   
            }
        }

        return min;
    }
}