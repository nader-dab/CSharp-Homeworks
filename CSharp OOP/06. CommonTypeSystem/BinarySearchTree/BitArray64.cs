namespace BitArray64
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BitArray64 : IEnumerable<int>
    {
        private ulong number;
        private byte[] internalArray;

        public BitArray64(ulong number)
        {
            this.Number = number;
            this.InternalArray = this.GetBits(this.Number);
        }

        public ulong Number
        {
            get
            {
                return this.number;
            }

            set
            {
                this.number = value;
            }
        }

        private byte[] InternalArray
        {
            get
            {
                return this.internalArray;
            }

            set
            {
                this.internalArray = value;
            }
        }

        public int this[int index]
        {
            get
            {
                if (index < 0 || index >= 64)
                {
                    throw new IndexOutOfRangeException("The index value must be between 0 and 63");
                }

                return this.InternalArray[this.internalArray.Length - 1 - index];
            }
        }        

        public static bool operator ==(BitArray64 firstArray, BitArray64 secondArray)
        {
            return BitArray64.Equals(firstArray, secondArray);
        }

        public static bool operator !=(BitArray64 firstArray, BitArray64 secondArray)
        {
            return !BitArray64.Equals(firstArray, secondArray);
        }

        public override bool Equals(object param)
        {
            if (!(param is BitArray64))
            {
                return false;
            }

            BitArray64 bitArray = param as BitArray64;

            if (bitArray.Number != this.Number)
            {
                return false;
            }

            if (!object.Equals(bitArray.Number, this.InternalArray))
            {
                return false;
            }

            return true;
        }

        public IEnumerator<int> GetEnumerator()
        {
            for (int index = this.InternalArray.Length - 1; index >= 0; index--)
            {
                yield return this[index];
            }
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override int GetHashCode()
        {
            return this.Number.GetHashCode() ^ this.InternalArray.GetHashCode();
        }

        private byte[] GetBits(ulong number)
        {
            int counter = 64;
            byte[] array = new byte[counter];

            while (number != 0 || counter > 0)
            {
                counter--;
                if (number % 2 == 1)
                {
                    array[counter] = 1;
                }

                number = number / 2;
            }

            return array;
        }
    }
}