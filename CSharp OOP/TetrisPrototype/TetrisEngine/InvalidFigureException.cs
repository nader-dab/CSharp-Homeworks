using System;
using System.Linq;

namespace TetrisEngine
{
    public class InvalidFigureException : ApplicationException
    {
        private int Number { get; set; }
        public InvalidFigureException(string msg)
            : base(msg)
        {
        }

        public InvalidFigureException(string msg, Exception innerEx)
            : base(msg, innerEx)
        {
        }

        public InvalidFigureException(string msg, int number)
            : this(msg)
        {
            this.Number = number;
        }

        public override string Message
        {
            get
            {
                string result = string.Format("{0}: The number {1} is not in range[1-7]", base.Message, this.Number);
                return result;
            }
        }
    }
}
