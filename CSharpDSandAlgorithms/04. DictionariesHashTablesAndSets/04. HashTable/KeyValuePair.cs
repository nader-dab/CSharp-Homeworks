namespace _04.HashTable
{
    using System;
    using System.Text;

    public class KeyValuePair<K, V>
    {
        private K key;
        private V value;

        public KeyValuePair(K key, V value)
        {
            this.key = key;
            this.value = value;
        }

        public K Key
        {
            get
            {
                return this.key;
            }
        }

        public V Value
        {
            get
            {
                return this.value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("[");
            if (this.Key != null)
            {
                sb.Append(this.Key.ToString());
            }
            sb.Append(", ");
            if (this.Value != null)
            {
                sb.Append(this.Value.ToString());
            }
            sb.Append("]");
            return sb.ToString();
        }
    }
}
