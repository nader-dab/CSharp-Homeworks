//Didn't have time to finish. Check the other version.
namespace _03._2.FindWords
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            Trie trie = new Trie();
            trie.AddWord("tea");
            trie.AddWord("ted");
            trie.AddWord("terrible");
            trie.AddWord("ten");
            trie.AddWord("terrific");
            trie.AddWord("tenaciuos");
            trie.AddWord("tenant");
            trie.AddWord("what");
            trie.PrintDfs();
        }
    }
}
