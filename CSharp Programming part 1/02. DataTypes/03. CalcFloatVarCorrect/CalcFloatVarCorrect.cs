using System;

class CalcFloatVarCorrect
{
    static void Main()
    {
        float valOne = 5.00001f;
        float valTwo = 5.00001f;
        double valThree = 7.0000000133f;
        double valFour = 7.000000087f;
        decimal valFive = 6.000001m;
        decimal valSix = 6.000001m;
        Console.WriteLine(valOne == valTwo);
        Console.WriteLine(valThree == valFour);
        Console.WriteLine(valFive == valSix);
    }
}

