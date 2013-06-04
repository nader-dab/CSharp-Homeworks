namespace _13.LinkedQueue
{
    using System;

    public class CustomQueue<T>
    {
        private QueueItem<T> tail;

        private QueueItem<T> head;

        public CustomQueue()
        {
            this.tail = null;
            this.head = this.tail;
        }

        public int Count { get; private set; }

        public void Add(T value)
        {
            if (this.tail == null)
            {
                QueueItem<T> newItem = new QueueItem<T>(value);
                this.tail = newItem;
                this.head = this.tail;
            }
            else
            {
                QueueItem<T> newItem = new QueueItem<T>(value, this.tail);
                this.tail = newItem;
            }

            this.Count++;
        }

        public T Dequeue()
        {
            QueueItem<T> currentItem = this.head;

            if (this.tail != null)
	        {
                this.head = this.head.Next;
                this.Count--;
	        }
            
            return currentItem.Value;
        }
    }
}
