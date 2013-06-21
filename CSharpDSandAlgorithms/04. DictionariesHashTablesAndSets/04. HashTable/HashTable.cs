namespace _04.HashTable
{
    using System;
    using System.Collections.Generic;

    public class HashTable<K, V> : IEnumerable<KeyValuePair<K,V>>
    {
        private List<KeyValuePair<K, V>>[] table;
        private const int DefaultCapacity = 16;
        private const float DefaultLoadFactor = 0.75f;
        private int size;
        private int initialCapacity;
        private float loadFactor;
        private int threshold;

        public HashTable()
            :this(DefaultCapacity, DefaultLoadFactor)
        {
        }

        public HashTable(int capacity, float loadFactor)
        {
            this.initialCapacity = capacity;
            this.loadFactor = loadFactor;
            this.threshold = (int)this.loadFactor * this.initialCapacity;
            this.table = new List<KeyValuePair<K, V>>[this.initialCapacity];
            this.size = 0;
        }

        public void Clear()
        {
            this.table = new List<KeyValuePair<K, V>>[this.initialCapacity];
            this.size = 0;
        }

        public int Count
        {
            get
            {
                return this.size;
            }
        }

        private List<KeyValuePair<K, V>> FindChain(K key, bool createIfMissing)
        {
            int index = key.GetHashCode();
            index = Math.Abs(index % this.table.Length);

            if (this.table[index] == null && createIfMissing)
            {
                this.table[index] = new List<KeyValuePair<K, V>>();
            }

            return this.table[index];
        }

        public V Get(K key)
        {
            List<KeyValuePair<K, V>> chain = FindChain(key, false);

            if (chain != null)
            {
                foreach (var entry in chain)
                {
                    if (entry.Key.Equals(key))
                    {
                        return entry.Value;
                    }
                }
            }

            return default(V);
        }

        public V Set(K key, V value)
        {
            List<KeyValuePair<K, V>> chain = FindChain(key, true);

            for (int i = 0; i < chain.Count; i++)
            {
                KeyValuePair<K, V> entry = chain[i];

                if (entry.Key.Equals(key))
                {
                    KeyValuePair<K, V> newEntry = new KeyValuePair<K, V>(key, value);
                    chain[i] = newEntry;
                    return newEntry.Value;
                }
            }

            chain.Add(new KeyValuePair<K, V>(key, value));
            this.size++;
            if (this.size >= this.threshold)
            {
                this.Expand();
            }

            return default(V);
        }

        public V this[K key]
        {
            get
            {
                return this.Get(key);
            }

            set
            {
                this.Set(key, value);
            }
        }

        private void Expand()
        {
            int newCapacity = 2 * this.table.Length;
            List<KeyValuePair<K, V>>[] oldTable = this.table;
            this.table = new List<KeyValuePair<K, V>>[newCapacity];
            this.threshold = (int)this.loadFactor * newCapacity;

            foreach (var oldChain in oldTable)
            {
                if (oldChain != null)
                {
                    foreach (var entry in oldChain)
                    {
                        List<KeyValuePair<K, V>> chain = FindChain(entry.Key, true);
                        chain.Add(entry);
                    }
                }
            }
        }

        public bool Remove(K key)
        {
            List<KeyValuePair<K, V>> chain = this.FindChain(key, false);

            if (chain != null)
            {
                for (int i = 0; i < chain.Count; i++)
                {
                    if (chain[i].Key.Equals(key))
                    {
                        chain.RemoveAt(i);
                        return true;
                    }
                }
            }

            return false;
        }


        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach (var chain in this.table)
            {
                if (chain!= null)
                {
                    foreach (var entry in chain)
                    {
                        yield return entry;
                    }
                }
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
