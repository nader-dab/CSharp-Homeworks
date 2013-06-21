namespace _01.TreeTask
{
    using System;
    using System.Collections.Generic;

    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.Children = new List<Node<T>>();
        }

        public T Value { get; set; }

        public bool HasParent { get; set; }

        public Node<T> Parrent { get; set; }

        public List<Node<T>> Children { get; set; }

        public void AddChild(Node<T> child)
        {
            this.Children.Add(child);
        }
    }
}
