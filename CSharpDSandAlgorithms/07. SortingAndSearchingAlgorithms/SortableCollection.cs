namespace SortingHomework
{
    using System;
    using System.Collections.Generic;

    public class SortableCollection<T> where T : IComparable<T>
    {
        private readonly IList<T> items;

        public SortableCollection()
        {
            this.items = new List<T>();
        }

        public SortableCollection(IEnumerable<T> items)
        {
            this.items = new List<T>(items);
        }

        public IList<T> Items
        {
            get
            {
                return this.items;
            }
        }

        public void Sort(ISorter<T> sorter)
        {
            sorter.Sort(this.items);
        }

        public bool LinearSearch(T item)
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (this.items[i].CompareTo(item) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        public bool BinarySearch(T item)
        {
            int left = 0;
            int right = this.items.Count;
           

            while (left < right)
            {
                int middle = (right + left) / 2;

                if (this.items[middle].CompareTo(item) == 0)
                {
                    return true;
                }

                if (this.items[middle].CompareTo(item) == -1)
                {
                    left = middle + 1;
                }
                else
                {
                    right = middle - 1;
                }
            }

            return false;
        }

        public void Shuffle()
        {
            Random randomGenerator = new Random();
            T[] unshffuledItems = new T[this.items.Count];
            this.items.CopyTo(unshffuledItems, 0);
            int lastIndex = this.items.Count - 1;

            List<T> shuffledItems = new List<T>();

            while (lastIndex >=0)
            {
                int index = randomGenerator.Next(0, lastIndex+1);
                shuffledItems.Add(unshffuledItems[index]);
                unshffuledItems[index] = unshffuledItems[lastIndex];
                lastIndex--;
            }

            for (int i = 0; i < shuffledItems.Count; i++)
            {
                this.items[i] = shuffledItems[i];
            }

        }

        public void PrintAllItemsOnConsole()
        {
            for (int i = 0; i < this.items.Count; i++)
            {
                if (i == 0)
                {
                    Console.Write(this.items[i]);
                }
                else
                {
                    Console.Write(" " + this.items[i]);
                }
            }

            Console.WriteLine();
        }
    }
}
