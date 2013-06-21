namespace _03.BiDictionary
{
    using System;

    public class BiDictionaryDemo
    {
        public static void Main(string[] args)
        {
            BiDictionary<int, string, string> numbersDictionary = new BiDictionary<int, string, string>();

            numbersDictionary.Add(4, "IV", "Four");
            numbersDictionary.Add(4, "IV", "Chetiri");
            numbersDictionary.Add(4, "IV", "Vier");
            numbersDictionary.Add(4, "IV", "Quatro");
            numbersDictionary.Add(4, "IV", "Shi");

            Console.WriteLine(numbersDictionary.ContainsKey1(4));
            Console.WriteLine(numbersDictionary.ContainsKey2("IV"));
            Console.WriteLine(numbersDictionary.ContainsKey1andKey2(4, "IV"));
            Console.WriteLine(numbersDictionary.ContainsKey1(43));

            //var numberFourWords = numbersDictionary[4];
            //var numberFourWords = numbersDictionary["IV"];
            var numberFourWords = numbersDictionary[4,"IV"];

            foreach (var word in numberFourWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}
