namespace _13.LinkedQueue
{
    public class QueueItem <T>
    {
        public QueueItem(T value)
        {
            this.Value = value;
            this.Next = null;
        }

        public QueueItem(T value, QueueItem<T> prevItem)
        {
            this.Value = value;
            prevItem.Next = this;
        }
        
        public T Value { get; set; }

        public QueueItem<T> Next { get; set; }
    }
}
