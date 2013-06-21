namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class Quicksorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var result = this.QuickSort(collection);
            collection.Clear();
            (collection as List<T>).AddRange(result);
        }

        private IList<T> QuickSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            int middle = collection.Count / 2;

            T pivot = collection[middle];

            IList<T> smaller = new List<T>();
            IList<T> greater = new List<T>();

            for (int i = 0; i < collection.Count; i++)
            {
                if (i == middle)
                {
                    continue;
                }

                if (collection[i].CompareTo(pivot) == -1)
                {
                    smaller.Add(collection[i]);
                }
                else
                {
                    greater.Add(collection[i]);
                }
            }

            IList<T> sortedSmaller = QuickSort(smaller);
            
            IList<T> sortedGreater = QuickSort(greater);

            List<T> merged = new List<T>();

            merged.AddRange(sortedSmaller);
            merged.Add(pivot);
            merged.AddRange(sortedGreater);
            return merged;
        }
    }
}
