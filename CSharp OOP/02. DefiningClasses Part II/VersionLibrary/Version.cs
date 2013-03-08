namespace VersionLibrary
{
    using System;

    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Class | AttributeTargets.Interface 
        | AttributeTargets.Method | AttributeTargets.Enum, AllowMultiple = true)]

    public class VersionAttribute : System.Attribute
    {
        private int major;
        private int minor;

        public VersionAttribute(int major, int minor)
        {
            this.Major = major;
            this.Minor = minor;
        }

        public int Major
        {
            get
            {
                return this.major;
            }

            private set
            {
                this.major = value;
            }
        }

        public int Minor
        {
            get
            {
                return this.minor;
            }

            private set
            {
                this.minor = value;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}.{1}", this.Major, this.Minor);
        }
    }
}