namespace _01.TreeTask
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.SetIn(System.IO.File.OpenText("..\\..\\input.txt"));

            int nodeCount = int.Parse(Console.ReadLine());
            Node<int>[] nodes = new Node<int>[nodeCount];

            for (int i = 0; i < nodes.Length; i++)
            {
                nodes[i] = new Node<int>(i);
            }

            for (int i = 0; i < nodeCount - 1; i++)
            {
                string[] tokens = Console.ReadLine().Split(' ');
                int rootIndex = int.Parse(tokens[0]);
                int childIndex = int.Parse(tokens[1]);

                nodes[rootIndex].AddChild(nodes[childIndex]);
                nodes[childIndex].Parrent = nodes[rootIndex];
            }

            Node<int> root = FindRoot(nodes);
            Console.WriteLine(PrintTree(root));
            Console.WriteLine("The root is: {0}", root.Value);

            List<Node<int>> leafs = GetLeafs(nodes);
            Console.WriteLine("The leafs are {0}", string.Join(", ", leafs.Select(x => x.Value)));

            List<Node<int>> middleNodes = GetMiddleNodes(nodes);
            Console.WriteLine("The middle nodes are {0}", string.Join(", ", middleNodes.Select(x => x.Value)));

            int longestPath = FindLongestPath(root);
            Console.WriteLine("The longest path is {0}", longestPath);

            Console.WriteLine("Enter number to check subpath sum");
            int subpathSum = int.Parse(Console.ReadLine());

            foreach (var leaf in leafs)
            {
                Node<int> currentNode = leaf;
                int sum = leaf.Value;
                Stack<Node<int>> pathNodes = new Stack<Node<int>>();
                pathNodes.Push(new Node<int>(currentNode.Value));
                while (currentNode.Parrent != null)
                {
                    currentNode = currentNode.Parrent;
                    pathNodes.Push(new Node<int>(currentNode.Value));
                    sum += currentNode.Value;
                }

                if (sum == subpathSum)
                {
                    Node<int> tree = new Node<int>(pathNodes.Pop().Value);
                    ConstructTree(pathNodes, tree);
                    Console.WriteLine("Yes there is a path with sum {0}", sum);
                    Console.WriteLine(PrintTree(tree));
                }
            }


            Console.WriteLine("Enter number to check subtree sum");
            int subtreeSum = int.Parse(Console.ReadLine());

            foreach (var node in nodes)
            {
                int sum = CalculateSum(node);
                if (sum == subtreeSum)
                {
                    Console.WriteLine("The following trees have a sum of {0}", sum);
                    Console.Write(PrintTree(node));
                }
            } 
        }

        private static Node<int> ConstructTree(Stack<Node<int>> pathNodes, Node<int> node)
        {
            if (pathNodes.Count > 0)
            {
                node.AddChild(pathNodes.Pop());
                ConstructTree(pathNodes, node.Children[0]);
            }

            return node;
        }

        private static string PrintTree(Node<int> node)
        {
            StringBuilder sb = new StringBuilder();
            PrintTree(node, string.Empty, sb);
            return sb.ToString();
            
        }

        private static void PrintTree(Node<int> node, string space, StringBuilder sb)
        {
            sb.Append(space + node.Value + Environment.NewLine);

            foreach (var child in node.Children)
            {
                PrintTree(child, space + " ", sb);
            }
        }

        private static int CalculateSum(Node<int> node)
        {
            if (node.Children.Count == 0)
            {
                return node.Value;
            }

            int sum = node.Value;

            foreach (var child in node.Children)
            {
                sum += CalculateSum(child);
            }

            return sum;
        }


        private static int FindLongestPath(Node<int> node)
        {
            if (node.Children.Count == 0)
            {
                return 0;
            }

            int longestPath = 0;

            foreach (var child in node.Children)
            {
                longestPath = Math.Max(longestPath, FindLongestPath(child));
            }

            return longestPath + 1;
        }

        private static List<Node<int>> GetMiddleNodes(Node<int>[] nodes)
        {
            List<Node<int>> middleNodes = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Parrent != null && node.Children.Count > 0)
                {
                    middleNodes.Add(node);
                }
            }

            return middleNodes;
        }

        private static List<Node<int>> GetLeafs(Node<int>[] nodes)
        {
            List<Node<int>> leafs = new List<Node<int>>();

            foreach (var node in nodes)
            {
                if (node.Children.Count ==  0)
                {
                    leafs.Add(node);
                }
            }

            return leafs;
        }

        private static Node<int> FindRoot(Node<int>[] nodes)
        {
            for (int i = 0; i < nodes.Length; i++)
            {
                if (nodes[i].Parrent == null)
                {
                    return nodes[i];
                }
            }

            throw new ArgumentException("There is no root", "node");
        }
    }
}
