namespace _03.CustomException
{
    using System;

    public class InvalidRanceException<T> : ApplicationException
    {
        private T start;
        private T end;

        public InvalidRanceException(string message)
            : base(message)
        { 
        }

        public InvalidRanceException(string message, Exception innerEx)
            : base(message, innerEx)
        { 
        }

        public InvalidRanceException(string message, T start, T end)
            : base(message)
        {
            this.Start = start;
            this.End = end;
        }

        public InvalidRanceException(string message, T start, T end, Exception innerEx)
            : base(message, innerEx)
        {
            this.Start = start;
            this.End = end;
        }

        public T End
        {
            get
            {
                return this.end;
            }

            protected set
            {
                this.end = value;
            }
        }

        public T Start
        {
            get
            {
                return this.start;
            }

            protected set
            {
                this.start = value;
            }
        }

        public override string Message
        {
            get
            {
                if (this.Start != null && this.End != null)
                {
                    return string.Format("Value must be between {0} and {1}. {2})", this.Start, this.End, base.Message);
                }
                else
                {
                    return base.Message;
                }
            }
        }
    }
}
