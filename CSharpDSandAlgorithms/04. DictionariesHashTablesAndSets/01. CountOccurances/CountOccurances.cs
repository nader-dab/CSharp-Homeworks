namespace _01.CountOccurances
{
    using System;
    using System.Collections.Generic;

    public class CountOccurances
    {
        public static void Main(string[] args)
        {
            double[] numbers = new double[] { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            Dictionary<double, int> occurances = new Dictionary<double, int>();

            foreach (var number in numbers)
            {
                if (occurances.ContainsKey(number))
                {
                    occurances[number]++;
                }
                else
                {
                    occurances.Add(number, 1);
                }
            }

            foreach (var entry in occurances)
            {
                Console.WriteLine("{0} -> {1} times", entry.Key, entry.Value);
            }            
        }
    }
}
