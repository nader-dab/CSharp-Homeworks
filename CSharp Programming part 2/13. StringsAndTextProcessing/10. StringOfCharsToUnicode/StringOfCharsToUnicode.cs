using System;
using System.Text;

class Program
{
    static void Main()
    {
        Console.WriteLine("Please enter text:");
        string text = Console.ReadLine();
        string convertedText = ConvertTextToUnicode(text);
        Console.WriteLine(convertedText);
    }

    private static string ConvertTextToUnicode(string text)
    {
        StringBuilder sb = new StringBuilder();
        for (int index = 0; index < text.Length; index++)
        {
            sb.AppendFormat("\\u{0:X4}", (int)text[index]);
        }
        return sb.ToString();
    }
}
