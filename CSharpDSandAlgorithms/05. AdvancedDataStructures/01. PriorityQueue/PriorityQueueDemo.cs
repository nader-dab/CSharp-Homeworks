namespace _01.PriorityQueue
{
    using System;

    public class PriorityQueueDemo
    {
        public static void Main(string[] args)
        {
            BinaryHeap<int> priorityQueue = new BinaryHeap<int>();
            priorityQueue.Add(4);
            priorityQueue.Add(6);
            priorityQueue.Add(9);
            priorityQueue.Add(22);
            priorityQueue.Add(5);
            priorityQueue.Add(3);
            priorityQueue.Add(13);
            priorityQueue.Add(37);
            priorityQueue.Add(100);
            priorityQueue.Add(46);

            while (priorityQueue.Count > 0)
            {
                Console.WriteLine(priorityQueue.Remove());
            }
        }
    }
}
