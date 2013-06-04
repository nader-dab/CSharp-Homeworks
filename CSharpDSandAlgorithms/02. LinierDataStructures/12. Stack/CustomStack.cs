namespace _12.Stack
{
    using System;
    using System.Collections.Generic;

    public class CustomStack<T> : IEnumerable<T>
    {
        private const int InitialCapacity = 4;

        private T[] array = null;

        public CustomStack()
        {
            this.array = new T[InitialCapacity];
        }

        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                if (!IsInRange(0, this.Count - 1, index))
                {
                    throw new IndexOutOfRangeException("The index is outside the Stack range.");
                }

                return this.array[index];
            }
        }

        public void Push(T value)
        {
            this.InsertAt(this.Count, value);
        }

        public void InsertAt(int index, T value)
        {
            if (!IsInRange(0, this.Count, index))
            {
                throw new IndexOutOfRangeException("The index is outside the Stack range.");
            }

            T[] duplicatedArray = this.array;
            if (this.Count + 1 == this.array.Length)
            {
                duplicatedArray = new T[this.array.Length * 2];
            }

            Array.Copy(this.array, duplicatedArray, index);
            this.Count++;
            Array.Copy(this.array, index, duplicatedArray, index + 1, this.Count - index - 1);
            duplicatedArray[index] = value;
            this.array = duplicatedArray;
        }

        public int IndexOf(T value)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (object.Equals(this.array[i], value))
                {
                    return i;
                }
            }

            return -1;
        }

        public bool Contains(T value)
        {
            if (this.IndexOf(value) != -1)
            {
                return true;
            }

            return false;
        }

        public void Clear()
        {
            this.array = new T[InitialCapacity];
            this.Count = 0;
        }

        public T RemoveAt(int index)
        {
            if (!IsInRange(0, this.Count - 1, index))
            {
                throw new IndexOutOfRangeException("The index is outside the Stack range.");
            }

            T item = this.array[index];
            Array.Copy(this.array, index + 1, this.array, index, this.Count - index + 1);
            this.array[this.Count - 1] = default(T);
            this.Count--;
            return item;
        }

        public int Remove(T value)
        {
            int index = this.IndexOf(value);

            if (index != -1)
            {
                Array.Copy(this.array, index + 1, this.array, index, this.Count - index + 1);
                this.Count--;
            }

            return index;
        }

        public T Pop()
        {
            return this.RemoveAt(this.Count - 1);
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.Count - 1; i >= 0 ; i--)
            {
                yield return this.array[i];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private bool IsInRange(int min, int max, int value)
        {
            bool result = min <= value && value <= max;

            return result;
        }
    }
}
