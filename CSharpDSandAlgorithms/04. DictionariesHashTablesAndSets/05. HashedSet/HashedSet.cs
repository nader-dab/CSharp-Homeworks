namespace _05.HashedSet
{
    using _04.HashTable;
    using System;
    using System.Collections.Generic;
    public class HashedSet<T> : IEnumerable<T>
    {
        HashTable<T, int> innerDictionary;
        int count;

        public HashedSet() 
        {
            innerDictionary = new HashTable<T, int>();
            this.count = 0;
        }

        public bool Add(T value)
        {
            if (innerDictionary.Get(value) == 0)
            {
                innerDictionary[value] = 1;
                this.count++;
                return true;
            }

            return false;
        }

        public bool Find(T value)
        {
            if (innerDictionary[value] == 1)
            {
                return true;
            }

            return false;
        }

        public bool Remove(T value)
        {
            bool isInTable = innerDictionary.Remove(value);

            if (isInTable)
            {
                this.count--;
            }

            return isInTable; 
        }

        public int Count
        {
            get
            {
                return this.count;
            }
        }

        public void Clear()
        {
            this.innerDictionary = new HashTable<T, int>();
            this.count = 0;
        }

        public HashedSet<T> Intersect(HashedSet<T> other)
        {
            HashedSet<T> result = new HashedSet<T>();

            foreach (var entry in this.innerDictionary)
            {
                if (other.Find(entry.Key))
                {
                    result.Add(entry.Key);
                }
            }

            return result;
        }

        public HashedSet<T> Union(HashedSet<T> other)
        {
            HashedSet<T> result = new HashedSet<T>();
            foreach (var entry in this.innerDictionary)
            {
                result.Add(entry.Key);
            }

            foreach (var entry in other)
            {
                result.Add(entry);
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var entry in this.innerDictionary)
            {
                yield return entry.Key;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
