namespace _05.RemoveAllNegativeNumbers
{
    using System;
    using System.Collections.Generic;

    public class RemoveAllNegativeNumbers
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

            sequence.RemoveAll(x => x < 0);

            foreach (int number in sequence)
            {
                Console.WriteLine(number);
            }
        }
    }
}
