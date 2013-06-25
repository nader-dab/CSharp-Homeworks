namespace _01.Frames
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Frame
    {
        public Frame(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        public int X { get; set; }
        public int Y { get; set; }

        public override string ToString()
        {
            return string.Format("({0}, {1})", this.X, this.Y);
        }
    }
    public class Program
    {
        static SortedSet<string> allResults = new SortedSet<string>();
        static bool[] used;
        static List<Frame[]> frames = new List<Frame[]>();

        static void Main(string[] args)
        {
            int numberOfFrames = int.Parse(Console.ReadLine());

            Frame[] result = new Frame[numberOfFrames];

            for (int i = 0; i < numberOfFrames; i++)
            {
                string line = Console.ReadLine();
                string[] tokens = line.Split(' ');
                int x = int.Parse(tokens[0]);
                int y = int.Parse(tokens[1]);
                if (x == y)
                {
                    frames.Add(new[] { new Frame(x, y), new Frame(x, y) });
                }
                else
                {
                    frames.Add(new[] { new Frame(x, y), new Frame(y, x) });
                }
            }

            used = new bool[frames.Count];
            GenerateVariation(result, 0);

            Console.WriteLine(allResults.Count);
            foreach (var item in allResults)
            {
                Console.WriteLine(item);
            }
        }
        private static void GenerateVariation(Frame[] result, int position)
        {
            if (position == result.Length)
            {
                string posibleResult = string.Join(" | ", result.Select(x=>x));

                allResults.Add(posibleResult);
                
                return;
            }

            for (int i = 0; i < frames.Count; i++)
            {
                if (!used[i])
                {
                    result[position] = frames[i][0];
                    used[i] = true;
                    GenerateVariation(result, position + 1);
                    used[i] = false;
                    result[position] = frames[i][1];
                    used[i] = true;
                    GenerateVariation(result, position + 1);
                    used[i] = false;
                }
            }
        }
    }
}
