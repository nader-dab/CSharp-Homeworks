namespace _09.CalcQueueSequence
{
    using System;
    using System.Collections.Generic;

    public class CalcQueueSequence
    {
        private const int MembersCount = 50;

        public static void Main(string[] args)
        {
            Console.WriteLine("Please enter N:");
            int n = int.Parse(Console.ReadLine());

            Queue<int> calculationSequence = new Queue<int>();
            calculationSequence.Enqueue(n);

            Queue<int> members = new Queue<int>();

            while (members.Count < MembersCount)
            {
                int number = calculationSequence.Dequeue();
                calculationSequence.Enqueue(number + 1);
                calculationSequence.Enqueue((2 * number) + 1);
                calculationSequence.Enqueue(number + 2);
                members.Enqueue(number);
            }

            int lastMember = new Stack<int>(members).Pop();
            Console.WriteLine(lastMember);
        }
    }
}
