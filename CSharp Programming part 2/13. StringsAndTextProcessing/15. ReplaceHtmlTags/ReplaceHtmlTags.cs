using System;

class ReplaceHtmlTags
{
    static void Main()
    {
        Console.WriteLine("Please enter HTML text to modify");
        string htmlText = Console.ReadLine();
        string urlText = htmlText.Replace("</a>", "[/URL]");
        urlText = urlText.Replace("<a href=\"", "[URL=");
        urlText = urlText.Replace("\">", "]");
        Console.WriteLine(urlText);
    }
}