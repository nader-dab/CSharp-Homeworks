using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

public class ExtractDatesFromText
{
    public static void Main()
    {
        Console.WriteLine("Please enter text:");
        string text = Console.ReadLine();
        List<string> dates = ExtractDates(text);
        PrintDatesForCanada(dates);
    }

    private static void PrintDatesForCanada(List<string> dates)
    {
        CultureInfo ca = CultureInfo.GetCultureInfo("en-CA");
        DateTime canadaDate = new DateTime();
        foreach (var date in dates)
        {
            if (DateTime.TryParse(date, ca, DateTimeStyles.None, out canadaDate))
            {
                Console.WriteLine(canadaDate.ToShortDateString());
            }
        }
    }

    private static List<string> ExtractDates(string text)
    {
        List<string> dates = new List<string>();

        // Alternative pattern \b\d+?[./ ]\d+?[./ ]\d{4}\b
        string pattern = @"\b(3[0-1]|[1-2][0-9]|0??[1-9])[./ ](1[0-2]|0??[1-9])[./ ]([1-2][0-9][0-9][0-9])\b";
        Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
        MatchCollection matches = rgx.Matches(text);
        foreach (var match in matches)
        {
            dates.Add(match.ToString());
        }

        return dates;
    }
}
