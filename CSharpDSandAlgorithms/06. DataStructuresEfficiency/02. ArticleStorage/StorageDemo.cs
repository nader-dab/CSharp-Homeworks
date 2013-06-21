namespace _02.ArticleStorage
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Wintellect.PowerCollections;

    public class StorageDemo
    {
        const string ArticlesFile = @"../../articles.txt";
        static OrderedMultiDictionary<decimal, Article> storage = new OrderedMultiDictionary<decimal, Article>(true);
        const decimal MinPrice = 50;
        const decimal MaxPrice = 450;

        public static void Main(string[] args)
        {
            ReadInputFile();
            var articlesInPriceRange = storage.Range(MinPrice, true, MaxPrice, true);

            foreach (var entry in articlesInPriceRange)
            {
                Console.WriteLine("{0}: {1}", entry.Key, entry.Value);
            }
        }

        private static void ReadInputFile()
        {
            string[] text = File.ReadAllLines(ArticlesFile);

            for (int i = 0; i < text.Length; i++)
            {
                string line = text[i];
                string[] tokens = line.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                string barcode = tokens[0].Trim();
                string vendor = tokens[1].Trim();
                string title = tokens[2].Trim();
                decimal price = decimal.Parse(tokens[3].Trim());
                Article curentArticle = new Article(barcode, vendor,title, price);

                if (storage.ContainsKey(price))
                {
                    storage[price].Add(curentArticle);
                }
                else
                {
                    storage.Add(price, curentArticle);
                }
            }
        }
    }
}
