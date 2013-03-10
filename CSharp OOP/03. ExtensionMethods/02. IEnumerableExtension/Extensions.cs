namespace _02.IEnumerableExtension
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {
        public static T ExtensionSum<T>(this IEnumerable<T> collection)
        {
            decimal result = 0;

            foreach (var item in collection)
            {
                result += Convert.ToDecimal(item);
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public static T ExtensionProduct<T>(this IEnumerable<T> collection)
        {
            decimal result = 1;

            foreach (var item in collection)
            {
                result *= Convert.ToDecimal(item);
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public static T ExtensionMin<T>(this IEnumerable<T> collection)
        {
            decimal result = decimal.MaxValue;

            foreach (var item in collection)
            {
                if (Convert.ToDecimal(item) < result)
                {
                    result = Convert.ToDecimal(item);
                }
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public static T ExtensionMax<T>(this IEnumerable<T> collection)
        {
            decimal result = decimal.MinValue;

            foreach (var item in collection)
            {
                if (Convert.ToDecimal(item) > result)
                {
                    result = Convert.ToDecimal(item);
                }
            }

            return (T)Convert.ChangeType(result, typeof(T));
        }

        public static T ExtensionAvarage<T>(this IEnumerable<T> collection)
        {
            decimal result = 0;

            foreach (var item in collection)
            {
                result += Convert.ToDecimal(item);
            }

            result = result / collection.Count();

            return (T)Convert.ChangeType(result, typeof(T));
        }
    }
}