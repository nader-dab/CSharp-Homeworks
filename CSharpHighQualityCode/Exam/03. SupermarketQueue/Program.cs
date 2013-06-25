namespace _03.SupermarketQueue
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Wintellect.PowerCollections;

    public class Program
    {
        static BigList<string> queueOfPositions = new BigList<string>();

        static Dictionary<string, int> queueOfNames = new Dictionary<string, int>();

        static int uniqueClientId = 0;
        static StringBuilder result = new StringBuilder();
        static void Main(string[] args)
        {
            string line = Console.ReadLine();

            while (line != string.Empty)
            {
                string[] tokens = line.Split(' ');

                if (line.StartsWith("Append"))
                {
                    AppendPerson(tokens[1]);
                }
                else if (line.StartsWith("Insert"))
                {
                    InsertPerson(int.Parse(tokens[1]), tokens[2]);
                }
                else if (line.StartsWith("Find"))
                {
                    FindPerson(tokens[1]);
                }
                else if (line.StartsWith("Serve"))
                {
                    ServePeople(int.Parse(tokens[1]));
                }
                else if (line.StartsWith("End"))
                {
                    Console.Write(result.ToString());
                    break;
                }

                line = Console.ReadLine();
            }
        }

        private static void ServePeople(int count)
        {
            if (count > queueOfPositions.Count)
            {
                result.AppendLine("Error");
                return;
            }

            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < count; i++)
            {
                string name = queueOfPositions[0];
                sb.Append(string.Format("{0} ", name));
                queueOfPositions.RemoveAt(0);
                queueOfNames[name]--;
            }
            sb.Length--;

            result.AppendLine(sb.ToString());
        }

        private static void FindPerson(string name)
        {
            if (!queueOfNames.ContainsKey(name))
            {
                result.AppendLine("0");

            }
            else
            {
                result.AppendLine(queueOfNames[name].ToString());
            }
        }

        private static void InsertPerson(int position, string name)
        {
            if (position > queueOfPositions.Count)
            {
                result.AppendLine("Error");
                return;
            }

            queueOfPositions.Insert(position, name);
            if (!queueOfNames.ContainsKey(name))
            {
                queueOfNames.Add(name, 0);
            }
            queueOfNames[name]++;

            uniqueClientId++;
            result.AppendLine("OK");
        }

        private static void AppendPerson(string name)
        {
            queueOfPositions.Add(name);
            if (!queueOfNames.ContainsKey(name))
            {
                queueOfNames.Add(name, 0);
            }
            queueOfNames[name]++;
            uniqueClientId++;
            result.AppendLine("OK");
        }
    }
}
