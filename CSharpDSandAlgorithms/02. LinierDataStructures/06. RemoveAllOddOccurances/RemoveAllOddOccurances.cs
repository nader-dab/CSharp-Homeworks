namespace _06.RemoveAllOddOccurances
{
    using System;
    using System.Collections.Generic;

    public class RemoveAllOddOccurances
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

            List<int> filteredSequence = new List<int>();

            foreach (var number in sequence)
            {
                var occurances = sequence.FindAll(x => x == number);

                if (occurances.Count % 2 == 0)
                {
                    filteredSequence.Add(number);
                }
            }

            sequence = filteredSequence;

            foreach (int number in sequence)
            {
                Console.WriteLine(number);
            }
        }
    }
}
