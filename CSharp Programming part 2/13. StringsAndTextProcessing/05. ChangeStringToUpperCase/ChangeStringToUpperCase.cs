using System;

public class ChangeStringToUpperCase
{
    public static void Main()
    {
        Console.WriteLine("Please enter a string: ");
        string inputString = Console.ReadLine();
        string openningTag = "<upcase>";
        string closingTag = "</upcase>";
        int openningTagPosition = -1;
        int closingTagPosition = -1;
        while (true)
        {
            openningTagPosition = inputString.IndexOf(openningTag);
            closingTagPosition = inputString.IndexOf(closingTag);
            char[] array = inputString.ToCharArray();
            for (int i = openningTagPosition + openningTag.Length; i < closingTagPosition; i++)
            {
                array[i] = char.ToUpper(array[i]);
            }

            inputString = new string(array);

            if (openningTagPosition != -1)
            {
                inputString = inputString.Remove(openningTagPosition, openningTag.Length);
                inputString = inputString.Remove(closingTagPosition - openningTag.Length, closingTag.Length);
            }

            if (openningTagPosition == -1)
            {
                break;
            }
        }

        Console.WriteLine(inputString);
    }
}