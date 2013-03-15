namespace _03.CustomException
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            int outOfRangeNumber = 45;
            DateTime outOfRangeDate = new DateTime(2024, 12, 31);

            CheckNumber(outOfRangeNumber);
            CheckDate(outOfRangeDate);
        }

        private static void CheckDate(DateTime outOfRangeDate)
        {
            if (outOfRangeDate.Year < 1980 || outOfRangeDate.Year > 2013)
            {
                throw new InvalidRanceException<DateTime>("Invalid range", new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));
            }
        }

        private static void CheckNumber(int outOfRangeNumber)
        {
            if (outOfRangeNumber < 1 || outOfRangeNumber > 100)
            {
                throw new InvalidRanceException<int>("Invalid range", 1, 100);
            }
        }
    }
}
