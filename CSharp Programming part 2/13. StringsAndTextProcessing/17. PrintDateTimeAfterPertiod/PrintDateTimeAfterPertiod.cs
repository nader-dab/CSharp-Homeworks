using System;
using System.Globalization;
using System.Threading;

class PrintDateTimeAfterPertiod
{
    static void Main()
    {
        Console.WriteLine("Please enter day.month.year hour:minute:second"); //24.03.2013 13:33:03
        string input = Console.ReadLine();
        //DateTime time = DateTime.ParseExact(input, "dd.MM.yyyy HH:mm:ss", CultureInfo.InvariantCulture);
        DateTime time = DateTime.Parse(input);
        time = time.AddHours(6);
        time = time.AddMinutes(30);
        CultureInfo bg = CultureInfo.GetCultureInfo("bg-BG");
        Console.WriteLine("{0:dd.MM.yyyy HH:mm:ss} {1}", time, time.ToString("dddd", bg));
    }
}
