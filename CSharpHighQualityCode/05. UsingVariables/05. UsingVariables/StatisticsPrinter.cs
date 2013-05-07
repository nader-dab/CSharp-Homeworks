namespace _05.UsingVariables
{
    using System;

    public class StatisticsPrinter
    {
        public void PrintStatistics(double[] statistics, int count)
        {
            double max = this.GetMax(statistics, count);
            double min = this.GetMin(statistics, count);
            double avg = this.GetAvg(statistics, count);

            Console.WriteLine(max);
            Console.WriteLine(min);
            Console.WriteLine(avg);
        }

        private double GetAvg(double[] statistics, int count)
        {
            double sum = 0;

            for (int i = 0; i < count; i++)
            {
                sum += statistics[i];
            }

            double avarage = sum / count;

            return avarage;
        }

        private double GetMin(double[] statistics, int count)
        {
            double min = double.MaxValue;

            for (int i = 0; i < count; i++)
            {
                if (statistics[i] < min)
                {
                    min = statistics[i];
                }
            }

            return min;
        }

        private double GetMax(double[] statistics, int count)
        {
            double max = double.MinValue;

            for (int i = 0; i < count; i++)
            {
                if (statistics[i] > max)
                {
                    max = statistics[i];
                }
            }

            return max;
        }
    }
}
