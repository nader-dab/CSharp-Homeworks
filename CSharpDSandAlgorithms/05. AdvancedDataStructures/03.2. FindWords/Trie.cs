namespace _03._2.FindWords
{
    using System;
    using System.IO;
    using System.Text.RegularExpressions;

    public class Trie
    {
        private char root;
        private Trie[] children;

        public Trie()
        {
            this.root = default(char);
            this.children = new Trie[26];
        }

        private Trie(string word)
        {
            this.root = word[0];
            this.children = new Trie[26];
            this.AddWord(word.Substring(1));
        }

        public void AddWord(string word)
        {
            if (word.Length < 1)
            {
                return;
            }

            if (!char.IsLetter(word[0]))
            {
                return;
            }

            int index = (int)word[0] - 97;

            if (this.children[index] == null)
            {
                this.children[index] = new Trie(word);
            }
            else
            {
                this.children[index].AddWord(word.Substring(1));
            }
        }

        public void PrintDfs()
        {
            PrintDfs(this, string.Empty);
        }

        private void PrintDfs(Trie trie, string spaces)
        {
            Console.WriteLine("{0}{1}", spaces, trie.root);

            foreach (var child in trie.children)
	        {
                if (child != null)
	            {
                    PrintDfs(child, spaces + " ");
	            }
	        }
        }

        public void CreatePrefixTree(string textFile)
        {
            string text = File.ReadAllText(textFile);
            Regex rgx = new Regex("\\b\\w+\\b", RegexOptions.IgnoreCase);
            MatchCollection matches = rgx.Matches(text);
            foreach (var word in matches)
            {
                string lowerLetterWord = word.ToString().ToLower();
                this.AddWord(lowerLetterWord);
            }
        }
    }
}
