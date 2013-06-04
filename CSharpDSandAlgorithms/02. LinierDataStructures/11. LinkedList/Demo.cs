namespace _11.LinkedList
{
    using System;

    public class Demo
    {
        public static void Main(string[] args)
        {
            LinkedList<int> demoList = new LinkedList<int>();
            demoList.Add(1);
            demoList.Add(55);
            demoList.Add(3);
            demoList.Add(4);

            demoList[1] = 2;

            foreach (int number in demoList)
            {
                Console.WriteLine(number);
            }

            Console.WriteLine();
            Console.WriteLine(demoList.IndexOf(1));
            Console.WriteLine(demoList.Contains(4));

            Console.WriteLine();
            Console.WriteLine(demoList.IndexOf(112));
            Console.WriteLine(demoList.Contains(423));

            Console.WriteLine();
            demoList.Remove(1);
            demoList.RemoveAt(2);

            foreach (int number in demoList)
            {
                Console.WriteLine(number);
            }
        }
    }
}
