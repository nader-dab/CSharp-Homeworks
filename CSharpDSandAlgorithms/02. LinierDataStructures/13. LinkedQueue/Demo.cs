namespace _13.LinkedQueue
{
    using System;

    public class Demo
    {
        public static void Main(string[] args)
        {
            CustomQueue<int> queue = new CustomQueue<int>();
            queue.Add(5);
            queue.Add(55);
            queue.Add(96);
            queue.Add(123);
            queue.Add(234);

            while (queue.Count > 0)
            {
                Console.WriteLine(queue.Dequeue());
            }
        }
    }
}
