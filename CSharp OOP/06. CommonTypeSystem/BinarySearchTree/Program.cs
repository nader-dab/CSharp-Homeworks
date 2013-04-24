namespace BitArray64
{
    using System;

    public class Program
    {
        public static void Main(string[] args)
        {
            var array = new BitArray64(3);
            Console.WriteLine(array[1]);
            Console.WriteLine(string.Join(string.Empty, array));      
        }
    }
}
