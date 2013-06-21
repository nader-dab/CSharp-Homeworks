namespace _04.HashTable
{
    using System;

    public class HashTableDemo
    {
        public static void Main(string[] args)
        {
            string[] wordSequence = new string[] { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            HashTable<string, int> occurances = new HashTable<string, int>();

            foreach (var word in wordSequence)
            {
                occurances[word]++;
            }

            foreach (var entry in occurances)
            {
                Console.WriteLine(entry);
            }
        }
    }
}
