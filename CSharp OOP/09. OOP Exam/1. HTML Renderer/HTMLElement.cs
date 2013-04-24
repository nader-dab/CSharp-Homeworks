using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HTMLRenderer
{
    public class HTMLElement : IElement
    {
        public string Name { get; set; }
        public string TextContent { get; set; }
        public IEnumerable<IElement> ChildElements { get; set; }

        private List<IElement> innerList = new List<IElement>();
        public HTMLElement(string name, string textContent)
        {
            this.Name = name;
            this.TextContent = textContent;
            this.ChildElements = new List<HTMLElement>();
        }

        public void AddElement(IElement element)
        {
            innerList.Add(element);
        }

        public virtual void Render(StringBuilder output)
        {
            if (this.Name != null)
            {
                output.Append("<");
                output.Append(this.Name);
                output.Append(">");
            }

            if (this.TextContent != null)
            {
                this.TextContent = this.TextContent.Replace("&", "&amp;");
                this.TextContent = this.TextContent.Replace("<", "&lt;");
                this.TextContent = this.TextContent.Replace(">", "&gt;");
                
                output.Append(this.TextContent);
            }
           
            //TODO add child content
            foreach (var item in this.innerList)
            {
                StringBuilder childSb = new StringBuilder();
                item.Render(childSb);
                output.Append(childSb.ToString());
            }

            if (this.Name!= null)
            {
                output.Append("</");
                output.Append(this.Name);
                output.Append(">");
            }
           
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            this.Render(sb);
            return sb.ToString();
        }
    }
}
