using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeJewels.Models
{
    public class CodeJewel
    {
        public int Id { get; set; }
        public virtual Category Category { get; set; }
        public string AuthorMail { get; set; }
        public string SourceCode { get; set; }
        public ICollection<Vote> Votes { get; set; }

        public CodeJewel()
        {
            this.Votes = new HashSet<Vote>();
        }
    }
}
