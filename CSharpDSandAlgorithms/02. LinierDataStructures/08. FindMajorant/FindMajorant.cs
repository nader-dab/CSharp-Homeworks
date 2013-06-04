namespace _08.FindMajorant
{
    using System;
    using System.Collections.Generic;

    public class FindMajorant
    {
        public static void Main(string[] args)
        {
            int[] numbers = new int[] { 2, 2, 3, 3, 2, 3, 4, 3, 3 };

            Dictionary<int, int> majorantCandidates = new Dictionary<int, int>();

            foreach (var number in numbers)
            {
                if (majorantCandidates.ContainsKey(number))
                {
                    majorantCandidates[number]++;
                }
                else
                {
                    majorantCandidates.Add(number, 1);
                }
            }

            Tuple<int, int> numberAndOccurance = new Tuple<int, int>(0, 0);

            foreach (var candidate in majorantCandidates)
            {
                if (candidate.Value > numberAndOccurance.Item2)
                {
                    numberAndOccurance = new Tuple<int, int>(candidate.Key, candidate.Value);
                }
            }

            if (numberAndOccurance.Item2 >= numbers.Length / 2)
            {
                Console.WriteLine("The majorant is {0} and it appears {1} times", numberAndOccurance.Item1, numberAndOccurance.Item2);
            }
            else
            {
                Console.WriteLine("There is no majorant.");
            }
        }
    }
}
