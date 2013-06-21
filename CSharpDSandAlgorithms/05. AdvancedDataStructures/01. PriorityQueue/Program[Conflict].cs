using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.PriorityQueue
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BinaryHeap<int> test = new BinaryHeap<int>();
            test.Add(4);
            test.Add(6);
            test.Add(9);
            test.Add(23);


            Console.WriteLine(test.Count);
        }
    }
}
