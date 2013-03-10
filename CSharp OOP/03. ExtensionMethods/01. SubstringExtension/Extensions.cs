namespace _01.SubstringExtension
{
    using System;
    using System.Text;

    public static class Extensions
    {
        public static StringBuilder Substring(this StringBuilder sb, int startIndex, int length)
        {
            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("The index must be a non-negative value");
            }

            if (startIndex > sb.Length)
            {
                throw new ArgumentOutOfRangeException("The index must be smaller than the length of the StringBiulder");
            }

            if (length < 0)
            {
                throw new ArgumentOutOfRangeException("The length must be a non-negative value");
            }

            if (startIndex + length > sb.Length)
            {
                throw new ArgumentOutOfRangeException("The substring index plus length must not be larger than the length of the StringBiulder");
            }

            StringBuilder subSb = new StringBuilder();

            for (int index = startIndex; index < startIndex + length; index++)
            {
                subSb.Append(sb[index]);
            }

            return subSb;
        }
    }
}