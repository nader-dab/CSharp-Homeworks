using System;

class GetMax
{
    static void Main()
    {
        Console.Write("Enter number 1: ");
        int number1 = int.Parse(Console.ReadLine());
        Console.Write("Enter number 2: ");
        int number2 = int.Parse(Console.ReadLine());
        Console.Write("Enter number 3: ");
        int number3 = int.Parse(Console.ReadLine());

        int result = GetMaxNumber(number1, number2);
        result = GetMaxNumber(result, number3);
        Console.WriteLine("The biggest number is: {0}", result);
    }
    static int GetMaxNumber(int a, int b)
    {
        if (a > b)
        {
            return a;
        }
        else
        {
            return b;
        }
    }
}

