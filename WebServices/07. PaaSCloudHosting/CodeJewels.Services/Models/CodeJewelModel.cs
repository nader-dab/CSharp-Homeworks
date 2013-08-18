using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeJewels.Services.Models
{
    public class CodeJewelModel
    {
        public int Id { get; set; }

        public string AuthorMail { get; set; }

        public string SourceCode { get; set; }
    }

    public class CodeJewelDetailsModel : CodeJewelModel
    {

        public int Rating { get; set; }

        public string Category { get; set; }
    }
}