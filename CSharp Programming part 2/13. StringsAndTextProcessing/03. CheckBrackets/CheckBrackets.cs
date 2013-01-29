using System;

public class CheckBrackets
{
    public static void Main()
    {
        CheckBracketsInExpression();
    }
  
    private static void CheckBracketsInExpression()
    {
        try
        {
            Console.WriteLine("Please enter expression: ");
            string expression = Console.ReadLine();
            int brackets = 0;
            for (int index = 0; index < expression.Length; index++)
            {
                if (expression[index] == '(')
                {
                    brackets++;
                }

                if (expression[index] == ')')
                {
                    brackets--;
                }

                if (brackets < 0)
                {
                    throw new ArgumentException("Incorrect expression!");
                }
            }

            if (brackets != 0)
            {
                throw new ArgumentException("Incorrect expression!");
            }

            Console.WriteLine("Correct expression.");
        }
        catch (ArgumentException ae)
        {
            Console.Error.WriteLine("{0}", ae.Message);
        }
    }
}