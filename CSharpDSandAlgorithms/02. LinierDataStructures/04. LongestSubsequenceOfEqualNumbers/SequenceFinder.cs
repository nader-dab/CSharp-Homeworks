namespace _04.LongestSubsequenceOfEqualNumbers
{
    using System;
    using System.Collections.Generic;

    public class SequenceFinder
    {
        public SequenceFinder()
        {
        }

        public List<int> GetEqualNumbersSubsequence(List<int> numbers)
        {
            if (numbers.Count == 0)
            {
                return new List<int>();
            }

            int bestStart = 0;
            int bestLength = 1;

            for (int i = 0; i < numbers.Count - 1; i++)
            {
                int maxLength = 1;

                for (int j = i; j < numbers.Count - 1; j++)
                {
                    if (numbers[j] == numbers[j + 1])
                    {
                        maxLength++;
                    }
                    else
                    {
                        break;
                    }
                }

                if (maxLength > bestLength)
                {
                    bestStart = i;
                    bestLength = maxLength;
                }
            }

            List<int> bestSubSequence = numbers.GetRange(bestStart, bestLength);

            return bestSubSequence;
        }
    }
}
