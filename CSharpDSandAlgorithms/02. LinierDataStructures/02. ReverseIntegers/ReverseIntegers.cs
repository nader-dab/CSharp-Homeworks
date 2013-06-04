namespace _02.ReverseIntegers
{
    using System;
    using System.Collections.Generic;

    public class ReverseIntegers
    {
        public static void Main(string[] args)
        {
            Console.Write("Please enter N: ");
            int n = int.Parse(Console.ReadLine());

            Stack<int> sequence = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                Console.Write("Please enter element[{0}]: ", i);
                int number = int.Parse(Console.ReadLine());
                sequence.Push(number);
            }

            Console.WriteLine("Reversed sequence:");
            while (sequence.Count > 0)
            {
                int number = sequence.Pop();
                Console.WriteLine(number);
            }
        }
    }
}
