using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crawler
{
    public class UrlLink
    {
        private string realAddress;
        private string displayAddress;

        public UrlLink(string fullAddress)
            : this(fullAddress, null)
        {
        }
        public UrlLink(string fullAddress, string relAddress) 
        {
            this.RealAddress = fullAddress;
            this.DisplayAddress = relAddress;
        }

        public string RealAddress
        {
            get
            {
                return this.realAddress;
            }
            set
            {
                this.realAddress = value;
            }
        }

        public string DisplayAddress
        {
            get
            {
                return this.displayAddress;
            }

            set
            {
                this.displayAddress = value;
            }
        }

        public override string ToString()
        {
            return this.realAddress + " || " + this.displayAddress;
        }
    }
}
