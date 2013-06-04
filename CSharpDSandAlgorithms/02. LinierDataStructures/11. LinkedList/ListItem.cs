namespace _11.LinkedList
{
    public class ListItem<T>
    {
        public ListItem(T value)
        {
            this.Value = value;
            this.NextItem = null;
        }

        public ListItem(T value, ListItem<T> prevItem)
        {
            this.Value = value;
            prevItem.NextItem = this;
        }

        public T Value { get; set; }

        public ListItem<T> NextItem { get; set; }
    }
}
