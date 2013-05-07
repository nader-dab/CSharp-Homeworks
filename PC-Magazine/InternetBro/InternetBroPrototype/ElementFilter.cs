namespace Crawler
{
    using System.Text;

    class ElementFilter
    {
        private string inputText;
        private string elementId;

        public ElementFilter(string inputText, string elementId) 
        {
            this.inputText = inputText;
            this.elementId = elementId;
            this.ElementById = ExtractElementFromText(this.inputText, this.elementId);
        }

        public string ElementById { get; set; }

        private string ExtractElementFromText(string text, string element)
        {
            int position = text.IndexOf(element);

            if (position < 0)
            {
                return string.Empty; 
            }

            // Thank GOD that there is escaping of < with &lt in html
            int tagIndex = text.Substring(0, position).LastIndexOf("<");
            StringBuilder sb = new StringBuilder();

            tagIndex++;
            while (text[tagIndex] != ' ')
            {
                
                sb.Append(text[tagIndex]);
                tagIndex++;
            }

            string tag = sb.ToString();
            sb.Clear();

            int tagCount = 1;
            while (tagCount != 0)
            {
                tagIndex++;
                if (text[tagIndex] == '<')
                {
                    if (text.IndexOf(tag, tagIndex + 1) == tagIndex + 1)
                    {
                        tagCount++;
                    }

                    if (text.IndexOf("/" + tag, tagIndex + 1) == tagIndex + 1)
                    {
                        tagCount--;
                    }
                    
                }

                sb.Append(text[tagIndex]);
            }

            return sb.ToString();
        }

        
    }
}
