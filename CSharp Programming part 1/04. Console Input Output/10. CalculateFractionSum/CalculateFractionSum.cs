using System;

class CalculateFractionSum
{
    static void Main()
    {
        float oldsum = 1;
        float newSum = 1;
        int i = 2;
        do
        {
            oldsum = newSum;
            if (i % 2 == 0)
            {
                newSum = newSum + 1f / i;
            }
            else
            {
                newSum = newSum - 1f / i;
            }
            i++;
        }
        while (Math.Abs(newSum - oldsum)  > 0.001);
        Console.WriteLine("{0:0.000}", newSum);
    }
}

