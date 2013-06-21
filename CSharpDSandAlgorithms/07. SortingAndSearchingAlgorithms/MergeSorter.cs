namespace SortingHomework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class MergeSorter<T> : ISorter<T> where T : IComparable<T>
    {
        public void Sort(IList<T> collection)
        {
            var result = this.MergeSort(collection);
            collection.Clear();
            (collection as List<T>).AddRange(result);

        }

        private IList<T> MergeSort(IList<T> collection)
        {
            if (collection.Count <= 1)
            {
                return collection;
            }

            int middle = collection.Count / 2;
            List<T> left = new List<T>(collection).GetRange(0, middle);
            List<T> right = new List<T>(collection).GetRange(middle, collection.Count - middle);

            IList<T> sortedLeft = MergeSort(left);
            IList<T> sortedRight = MergeSort(right);

            return Merge(sortedLeft, sortedRight);
        }

        private IList<T> Merge(IList<T> left, IList<T> right)
        {
            List<T> merged = new List<T>();
            int leftIndex = 0;
            int rightIndex = 0;

            while (leftIndex < left.Count || rightIndex < right.Count)
            {
                if (leftIndex < left.Count && rightIndex < right.Count)
                {
                    if (left[leftIndex].CompareTo(right[rightIndex]) == -1)
                    {
                        merged.Add(left[leftIndex]);
                        leftIndex++;
                    }
                    else
                    {
                        merged.Add(right[rightIndex]);
                        rightIndex++;
                    }
                }
                else if (leftIndex < left.Count)
                {
                    merged.Add(left[leftIndex]);
                    leftIndex++;
                }
                else if (rightIndex < right.Count)
                {
                    merged.Add(right[rightIndex]);
                    rightIndex++;
                }
            }

            return merged;
        }
    }
}
