using System;

class CalcAgePlusTen
{
    static void Main()
    {
        byte ageNow=112;     
        Console.WriteLine("Please enter your age: ");
        if (byte.TryParse(Console.ReadLine(), out ageNow))
        {
            Console.WriteLine("your age in 10 years will be {0} ", ageNow + 10);
        }
        else { Console.WriteLine(ageNow); Main(); }
    }
}