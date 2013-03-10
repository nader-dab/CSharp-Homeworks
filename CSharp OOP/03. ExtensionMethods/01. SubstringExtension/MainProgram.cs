namespace _01.SubstringExtension
{
    using System;
    using System.Text;

    public class MainProgram
    {
        public static void Main(string[] args)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("grumpy wizzards");

            sb = sb.Substring(7, 8);

            Console.WriteLine(sb.ToString());
        }
    }
}