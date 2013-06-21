namespace _03.BiDictionary
{
    using System;
    using System.Collections.Generic;

    public class BiDictionary<K1, K2, V>
    {
        private Dictionary<K1, List<V>> firstDictionary;
        private Dictionary<K2, List<V>> secondDictionary;
        private Dictionary<string, List<V>> combinedDictionary;

        public BiDictionary()
        {
            this.firstDictionary = new Dictionary<K1, List<V>>();
            this.secondDictionary = new Dictionary<K2, List<V>>();
            this.combinedDictionary = new Dictionary<string, List<V>>();
        }

        public void Add(K1 key1, K2 key2, V value)
        {
            if (!this.ContainsKey1(key1))
            {
                List<V> entries = new List<V>();
                entries.Add(value);
                this.firstDictionary.Add(key1, entries);
            }
            else
            {
                this.firstDictionary[key1].Add(value);
            }

            if (!this.ContainsKey2(key2))
            {
                List<V> entries = new List<V>();
                entries.Add(value);
                this.secondDictionary.Add(key2, entries);
            }
            else
            {
                this.secondDictionary[key2].Add(value);
            }

            if (!this.ContainsKey1andKey2(key1, key2))
            {
                List<V> entries = new List<V>();
                entries.Add(value);
                this.combinedDictionary.Add(this.CombineKeys(key1, key2), entries);
            }
            else
            {
                this.combinedDictionary[this.CombineKeys(key1, key2)].Add(value);
            }
        }

        public ICollection<V> this[K1 index]
        {
            get
            {
                return this.firstDictionary[index];
            }
        }

        public ICollection<V> this[K2 index]
        {
            get
            {
                return this.secondDictionary[index];
            }
        }

        public ICollection<V> this[K1 index1, K2 index2]
        {
            get
            {
                return this.combinedDictionary[CombineKeys(index1, index2)];
            }
        }

        public bool ContainsKey1(K1 key)
        {
            bool result = this.firstDictionary.ContainsKey(key);
            return result;
        }

        public bool ContainsKey2(K2 key)
        {
            bool result = this.secondDictionary.ContainsKey(key);
            return result;
        }

        public bool ContainsKey1andKey2(K1 key1, K2 key2)
        {
            string combinedKey = CombineKeys(key1, key2);
            bool result = this.combinedDictionary.ContainsKey(combinedKey);
            return result;
        }

        private string CombineKeys(K1 key1, K2 key2)
        {
            string combinedKey = (key1 + " " + key2);
            return combinedKey;
        }
    }
}
