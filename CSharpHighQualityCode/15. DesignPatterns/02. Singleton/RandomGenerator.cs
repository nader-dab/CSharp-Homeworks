// ********************************
// <copyright file="ColorConsole.cs" company="Telerik Academy">
// Copyright (c) 2013 Telerik Academy. All rights reserved.
// </copyright>
// <author>Anon Telerik Student</author>
// ********************************
namespace _02.Singleton
{
    using System;

    public static class RandomGenerator
    {
        private static Random rand = null;

        static RandomGenerator()
        {
            if (rand == null)
            {
                rand = new Random();
            }
        }

        public static int Generate(int minValue, int maxValue)
        {
            return rand.Next(minValue, maxValue + 1);
        }
    }
}
