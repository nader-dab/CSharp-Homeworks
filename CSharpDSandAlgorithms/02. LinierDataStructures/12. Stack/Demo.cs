namespace _12.Stack
{
    using System;

    public class Demo
    {
        public static void Main(string[] args)
        {
            CustomStack<int> stack = new CustomStack<int>();
            stack.Push(4);
            stack.Push(5);
            stack.Push(6);
            stack.Push(7);

            foreach (var item in stack)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine(stack.Contains(7));

            Console.WriteLine();

            while (stack.Count > 0)
            {
                Console.WriteLine(stack.Pop());
            }
        }
    }
}
