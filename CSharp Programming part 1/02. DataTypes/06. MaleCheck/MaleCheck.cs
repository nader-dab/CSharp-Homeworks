using System;

class MaleCheck
{
    static void Main()
    {
        bool isMale = false;
        string answer;
        Console.WriteLine("Are you male? Answer Yes or No");
        answer = Console.ReadLine();
        if(answer == "Yes" || answer == "yes") {isMale = true;}
        Console.WriteLine("isMale value is: {0}", isMale);
    }
}


