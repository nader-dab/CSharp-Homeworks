namespace GenericListLibrary
{
    using System;
    using System.Linq;
    using System.Text;

    public class GenericList<T>
        where T : IComparable<T>    // Generic constraints for the class
    {
        private int capacity;   // Set generic list capacity
        private int count;      // Keep count of elements in the generic list
        private T[] array;      // Internal generic array that holds elements of the list  

        // Chained empty constructor
        public GenericList() : this(0)
        {
        }

        // Constructor that initializes initial values through properties
        public GenericList(int capacity)
        {
            this.Capacity = capacity;
            this.Count = 0;
            this.Array = new T[this.Capacity];
        }

        // Property for element count in the array
        public int Count
        {
            get 
            {
                return this.count;
            }

            private set
            {
                this.count = value;
            }
        }

        // Property for the capacity ot the private array
        public int Capacity
        {
            get
            {
                return this.capacity;
            }

            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Connot set list capacity with negative number");
                }

                if (value < this.Count)
                {
                    throw new ArgumentException("Cannot set capacity that is less than the current size");
                }

                this.capacity = value;
            }
        }

        // Property for the internal array used only by this class
        private T[] Array
        {
            get
            {
                return this.array;
            }

            set
            {
                this.array = value;
            }
        }

        // Indexer for the object instances of this class
        public T this[int index]
        {
            get
            {
                if (index < 0 || index > this.Count - 1)
                {
                    throw new ArgumentOutOfRangeException("Index was out of range. Must be between 0 and the size of the list");
                }

                return this.Array[index];
            }

            set
            {
                if (index < 0 || index > this.Count - 1)
                {
                    throw new ArgumentOutOfRangeException("Index was out of range. Must be between 0 and the size of the list");
                }

                this.Array[index] = value;
            }
        }

        // Adding elements at the end of the generic list
        public void Add(T element)
        {
            // Count of the elements is increases when adding
            this.Count++;

            // Resizes the internal array capacity if necessary
            this.CheckArrayCapacity();

            // Adds the elements at the end of the list instance
            this.Array[this.Count - 1] = element;
        }

        // Removing elements from the generic list by a given index
        public void RemoveAt(int index)
        {
            if (index < 0 || index > this.Count)
            {
                throw new ArgumentOutOfRangeException("Index must be within whe bouds of the list. ");
            }

            // Count of the elements is decreased by one when removing
            this.Count--;
            if (index == this.Count)
            {
                // If an element is being removed from the end of the generic list
                // its value is set to the default type value and we exit this method
                this.Array[this.count] = default(T);
                return;
            }

            // The values of the instance are copied to a temporary list and the value
            // at the given index is ommited
            T[] copyArray = new T[this.Capacity];

            for (int position = 0; position < index; position++)
            {
                copyArray[position] = this.Array[position];
            }

            for (int position = index + 1; position < this.Count + 1; position++)
            {
                copyArray[position - 1] = this.array[position];
            }

            // The current instance of the array is modified
            this.Array = copyArray.Clone() as T[];
        }

        public void InsertAt(int index, T element)
        { 
            if (index < 0 || index > this.Count + 1)
            {
                throw new ArgumentOutOfRangeException("Index must be within whe bouds of the list. ");
            }

            // Count of the elements is increased by one when inserting
            this.Count++;
            this.CheckArrayCapacity();

            if (index == this.Count)
            {
                // If an element is being inserted at the end of the generic list
                // its value is set at the end of the internal array instance and we exit this method
                this.Array[this.Count - 1] = element;
                return;
            }

            // The values of the instance are copied to a temporary list and the value
            // at the given index is included at the specific position
            T[] copyArray = new T[this.Capacity];

            for (int position = 0; position < index; position++)
            {
                copyArray[position] = this.Array[position];
            }

            copyArray[index] = element;

            for (int position = index; position < this.Count; position++)
            {
                copyArray[position + 1] = this.array[position];
            }

            // The current instance of the array is modified
            this.Array = copyArray.Clone() as T[];
        }

        // Removing all the elements from the internal array instance and reseting the
        // count and capacity
        public void Clear()
        {
            this.Count = 0;
            this.Capacity = 0;
            this.Array = new T[this.Capacity];
        }

        // Returns the first occurance of an element
        public int IndexOf(T element)
        {
            for (int index = 0; index < this.Count; index++)
            {
                if (this.Array[index].Equals(element))
                {
                    return index;
                }
            }

            return -1;
        }

        public T Min()
        {
            T element = this.Array.Min();
            return element;
        }

        public T Max()
        {
            T element = this.Array.Max();
            return element;
        }

        // Overrides ToString functionality
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < this.Count; index++)
            {
                sb.Append(string.Format("[{0}] ", this.Array[index].ToString()));
            }

            return sb.ToString();
        }

        // Checks if the capacity of the internal array is sufficient
        private void CheckArrayCapacity()
        {
            if (this.Count > this.Array.Length)
            {
                this.AutoGrowth();
            }
        }

        // Expands internal array capacity
        private void AutoGrowth()
        {
            // First expansion is with four elements
            // Each consecutive expansion doubles the array size
            if (this.Capacity == 0)
            {
                this.Capacity = 4;
            }
            else
            {
                this.Capacity *= 2;
            }

            // A new array is generated and the elemets of the current are transfered
            T[] copyArray = new T[this.Capacity];

            for (int index = 0; index < this.Array.Length; index++)
            {
                copyArray[index] = this.Array[index];
            }

            // The current instance of the array is modified
            this.Array = copyArray.Clone() as T[];
        }
    }
}
