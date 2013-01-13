using System;

class PrintTenthMember
{
    static void Main()
    {
        int firstMember = 2;
        for (int i = 0; i < 10; i++)
        {

            if (i % 2 == 0)
            {
                Console.WriteLine(firstMember);               
            }
            else
            {
                Console.WriteLine(firstMember * -1);
            }
            firstMember++;
        }
    }
}

