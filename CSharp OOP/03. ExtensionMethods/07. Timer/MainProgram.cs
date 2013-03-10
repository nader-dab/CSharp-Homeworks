namespace _07.UsingDelegatesTimer
{
    using System;

    public class MainProgram
    {
        public static void Main(string[] args)
        {
            Timer myTimer = new Timer(() => { Console.WriteLine("Helo there"); }, 2);
            myTimer.Observer += () => { Console.WriteLine(DateTime.Now); };
            myTimer.StartTimer();
        }
    }
}