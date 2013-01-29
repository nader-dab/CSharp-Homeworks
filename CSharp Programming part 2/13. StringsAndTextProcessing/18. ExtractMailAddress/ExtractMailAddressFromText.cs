using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

class ExtractMailAddressFromText
{
    static void Main()
    {
        Console.WriteLine("Please enter text:");
        string text = Console.ReadLine();
        List<string> mailAdresses = ExtractMailAddress(text);
        Console.WriteLine("Mail adresses from text:");
        foreach (var mail in mailAdresses)
        {
            Console.WriteLine(mail);
        }
    }

    private static List<string> ExtractMailAddress(string text)
    {
        List<string> mailAdresses = new List<string>();
        string pattern = @"\b\S*@\S*\b";
        Regex rgx = new Regex(pattern, RegexOptions.IgnoreCase);
        MatchCollection matches = rgx.Matches(text);
        foreach (var match in matches)
	    {
            mailAdresses.Add(match.ToString());
	    }
        return mailAdresses;
    }
}