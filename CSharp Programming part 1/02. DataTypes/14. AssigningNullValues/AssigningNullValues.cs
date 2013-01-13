using System;

class AssigningNullValues
{
    static void Main()
    {
        int? integerValue = null;
        double? doubleValue = null;
        Console.WriteLine("The null value of the integer variable is: {0}",integerValue);
        Console.WriteLine("The null value of the double variable is:{0}", doubleValue);

        integerValue = 24;
        doubleValue = 45;
        Console.WriteLine("{0}", integerValue);
        Console.WriteLine("{0}", doubleValue);
    }
}

