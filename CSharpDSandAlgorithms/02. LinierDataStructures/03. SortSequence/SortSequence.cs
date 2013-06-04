namespace _03.SortSequence
{
    using System;
    using System.Collections.Generic;

    public class SortSequence
    {
        public static void Main(string[] args)
        {
            List<int> sequence = new List<int>();
            while (true)
            {
                string line = Console.ReadLine();

                if (line == string.Empty)
                {
                    break;
                }

                int number = int.Parse(line);
                sequence.Add(number);
            }

            sequence.Sort();

            foreach (int number in sequence)
            {
                Console.WriteLine(number);
            }
        }
    }
}
