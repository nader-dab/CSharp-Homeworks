namespace _07.FindNumberOccurance
{
    using System;
    using System.Collections.Generic;

    public class FindNumberOccurance
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

            Dictionary<int, int> occurances = new Dictionary<int, int>();

            foreach (int number in sequence)
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
            
            foreach (var item in occurances)
            {
                Console.WriteLine("{0} -> {1}", item.Key, item.Value);
            }
        }
    }
}
