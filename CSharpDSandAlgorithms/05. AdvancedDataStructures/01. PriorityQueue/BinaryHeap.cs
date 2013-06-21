namespace _01.PriorityQueue
{
    using System;

    public class BinaryHeap<T>
        where T: IComparable<T>
    {
        private T[] table;
        private int index = 0;
        private const int InitialCapacity = 4;

        public BinaryHeap()
        {
            this.table = new T[InitialCapacity];
        }

        public int Count
        {
            get
            {
                return this.index;
            }
        }

        public void Add(T element)
        {
            if (this.index + 1 == this.table.Length)
            {
                ResizeTable();
            }

            this.table[this.index] = element;

            if (this.index != 0)
	        {
                int currentIndex = this.index;
                int parrentIndex = (currentIndex - 1) / 2;
               
                while (this.table[parrentIndex].CompareTo(this.table[currentIndex]) < 0)
	            {
                    T swap = this.table[parrentIndex];
                    this.table[parrentIndex] = this.table[currentIndex];
                    this.table[currentIndex] = swap;

                    currentIndex = parrentIndex;
                    parrentIndex = (currentIndex - 1) / 2;
	            }
	        }


            this.index++;
        }

        private void ResizeTable()
        {
            T[] newTable = new T[this.table.Length * 2];
            Array.Copy(this.table, newTable, this.table.Length);
            this.table = newTable;
        }

        public T Remove()
        {
            if (this.index == 0)
            {
                throw new ArgumentException("The heap is empty");
            }

            int bottomIndex = this.index - 1;

            T topElement = this.table[0];

            T bottomElement = this.table[bottomIndex];
            this.table[bottomIndex] = default(T);
            this.table[0] = bottomElement;

            int currentIndex = 0;
            int childIndex1 = 2 * currentIndex + 1;
            int childIndex2 = 2 * currentIndex + 2;

            while ((childIndex1 <this.table.Length && this.table[currentIndex].CompareTo(this.table[childIndex1]) < 0) ||
                (childIndex2 < this.table.Length && this.table[currentIndex].CompareTo(this.table[childIndex2]) < 0))
            {
                T swap = this.table[currentIndex];

                if (this.table[childIndex1].CompareTo(this.table[childIndex2]) > 0)
                {
                    this.table[currentIndex] = this.table[childIndex1];
                    this.table[childIndex1] = swap;
                    currentIndex = childIndex1;
                }
                else
                {
                    this.table[currentIndex] = this.table[childIndex2];
                    this.table[childIndex2] = swap;
                    currentIndex = childIndex2;

                }

                childIndex1 = 2 * currentIndex + 1;
                childIndex2 = 2 * currentIndex + 2;
                
            }

            this.index--;

            return topElement;
        }

        public T Peek()
        {
            if (this.index == 0)
            {
                throw new ArgumentException("The heap is empty");
            }

            T topElement = this.table[0];

            return topElement;
        }
    }
}