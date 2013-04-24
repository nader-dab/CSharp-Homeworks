using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocumentSystem
{
    public abstract class Document : IDocument
    {
        public string Name { get; protected set; }

        public string Content { get; protected set; }

        public virtual void LoadProperty(string key, string value)
        {
            if (key == "name")
            {
                this.Name = value;
            }

            if (key == "content")
            {
                this.Content = value;
            }
        }

        public virtual void SaveAllProperties(IList<KeyValuePair<string, object>> output)
        {
            output.Add(new KeyValuePair<string,object>("name", this.Name));
            output.Add(new KeyValuePair<string, object>("content", this.Content));
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.GetType().Name);
            sb.Append("[");
            List<KeyValuePair<string, object>> attributes = new List<KeyValuePair<string, object>>();
            this.SaveAllProperties(attributes);
            attributes = attributes.OrderBy(x => x.Key).ToList();

            foreach (var item in attributes)
            {
                if (item.Value!= null)
                {
                    sb.Append(item.Key);
                    sb.Append("=");
                    sb.Append(item.Value);
                    sb.Append(";");
                }
            }
            sb.Remove(sb.Length - 1, 1);
            sb.Append("]");
            return sb.ToString();
        }
    }
}
