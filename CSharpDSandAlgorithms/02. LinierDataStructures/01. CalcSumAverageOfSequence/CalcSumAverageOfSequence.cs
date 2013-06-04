namespace _01.CalcSumAverageOfSequence
{
    using System;
    using System.Collections.Generic;

    public class CalcSumAverageOfSequence
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

            long sum = 0;

            foreach (int number in sequence)
            {
                sum += number;
            }

            Console.WriteLine("The sum is {0}", sum);

            float average = sum / sequence.Count;
            Console.WriteLine("The average is {0:0.00}", average);
        }
    }
}
