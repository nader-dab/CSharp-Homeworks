namespace _11.LinkedList
{
    using System;
    using System.Collections.Generic;

    public class LinkedList<T> : IEnumerable<T>
    {
        public LinkedList()
        {
            this.FirstElement = null;
            this.LastElement = null;
        }

        public ListItem<T> FirstElement { get; private set; }

        public ListItem<T> LastElement { get; private set; }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (!this.IsInRange(0, this.Count - 1, index))
                {
                    throw new IndexOutOfRangeException("The index was outside the list dimensions.");
                }

                ListItem<T> currentItem = this.FirstElement;

                for (int i = 0; i < index; i++)
                {
                    currentItem = currentItem.NextItem;
                }

                return currentItem.Value;
            }

            set
            {
                if (!this.IsInRange(0, this.Count - 1, index))
                {
                    throw new IndexOutOfRangeException("The index was outside the list dimensions.");
                }

                ListItem<T> currentItem = this.FirstElement;

                for (int i = 0; i < index; i++)
                {
                    currentItem = currentItem.NextItem;
                }

                currentItem.Value = value;
            }
        }

        public void Add(T value)
        {
            if (this.FirstElement == null)
            {
                this.FirstElement = new ListItem<T>(value);
                this.LastElement = this.FirstElement;
            }
            else
            {
                ListItem<T> newItem = new ListItem<T>(value, this.LastElement);
                this.LastElement = newItem;
            }

            this.Count++;
        }

        public T RemoveAt(int index)
        {
            if (!this.IsInRange(0, this.Count - 1, index))
            {
                throw new IndexOutOfRangeException("The index was outside the list dimensions.");
            }

            ListItem<T> currentItem = this.FirstElement;
            ListItem<T> prevItem = null;

            for (int i = 0; i < index; i++)
            {
                prevItem = currentItem;
                currentItem = currentItem.NextItem;
            }

            this.Count--;

            if (this.Count == 0)
            {
                this.FirstElement = null;
            }
            else if (prevItem == null)
            {
                this.FirstElement = currentItem.NextItem;
            }
            else
            {
                prevItem.NextItem = currentItem.NextItem;
            }

            ListItem<T> lastItem = null;

            if (this.FirstElement != null)
            {
                lastItem = this.FirstElement;

                while (lastItem.NextItem != null)
                {
                    lastItem = lastItem.NextItem;
                }
            }

            this.LastElement = lastItem;

            return currentItem.Value;
        }

        public int Remove(T value)
        {
            ListItem<T> currentItem = this.FirstElement;
            ListItem<T> prevItem = null;

            int counter = 0;

            while (currentItem != null && !object.Equals(currentItem.Value, value))
            {
                prevItem = currentItem;
                currentItem = currentItem.NextItem;
                counter++;
            }

            if (currentItem != null)
            {
                this.Count--;

                if (this.Count == 0)
                {
                    this.FirstElement = null;
                }
                else if (prevItem == null)
                {
                    this.FirstElement = currentItem.NextItem;
                }
                else
                {
                    prevItem.NextItem = currentItem.NextItem;
                }

                ListItem<T> lastItem = null;

                if (this.FirstElement != null)
                {
                    lastItem = this.FirstElement;

                    while (lastItem.NextItem != null)
                    {
                        lastItem = lastItem.NextItem;
                    }
                }

                this.LastElement = lastItem;

                return counter;
            }
            else
            {
                return -1;
            }
        }

        public int IndexOf(T value)
        {
            ListItem<T> currentItem = this.FirstElement;

            int index = 0;

            while (currentItem != null && !object.Equals(currentItem.Value, value))
            {
                currentItem = currentItem.NextItem;
                index++;
            }

            if (currentItem != null)
            {
                return index;
            }
            else
            {
                return -1;
            }
        }

        public bool Contains(T value)
        {
            if (this.IndexOf(value) != -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            ListItem<T> currentItem = this.FirstElement;

            for (int i = 0; i < this.Count; i++)
            {
                yield return currentItem.Value;

                currentItem = currentItem.NextItem;
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private bool IsInRange(int min, int max, int value)
        {
            bool result = value >= min && value <= max;

            return result;
        }
    }
}
