namespace Generator
{
    using System;

    public static class RandomGenerator
    {
        private static Random rand;

        static RandomGenerator()
        {
            rand = new Random();
        }

        public static int Next(int minValue = 0, int maxValue = 0)
        {
            return rand.Next(minValue, maxValue + 1);
        }
    }
}