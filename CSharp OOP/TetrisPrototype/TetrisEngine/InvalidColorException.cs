using System;
using System.Linq;

namespace TetrisEngine
{
    public class InvalidColorException : ApplicationException
    {
        private int Number { get; set; }
        public InvalidColorException(string msg)
            : base(msg)
        {
        }

        public InvalidColorException(string msg, Exception innerEx)
            : base(msg, innerEx)
        {
        }

        public InvalidColorException(string msg, int number)
            : this(msg)
        {
            this.Number = number;
        }

        public override string Message
        {
            get
            {
                string result = string.Format("{0}: The number {1} is not in range[0-7],or default 999", base.Message, this.Number);
                return result;
            }
        }
    }
}
