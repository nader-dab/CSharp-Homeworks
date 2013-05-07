namespace Crawler
{
    using System.Text;
    using System.Text.RegularExpressions;

    public class LinkFilter
    {
        private string inputText;

        public LinkFilter(string inputText)
        {
            this.inputText = inputText;
        }

        public string AnchorTags 
        {
            get
            {
                return GetAnchorTags(this.inputText);
            }
        } 

        public string LinksFromHrefs 
        {
            get
            {
                return GetHrefAsText(this.inputText);
            }
        }

        private string GetAnchorTags(string inputText)
        {
            StringBuilder sb = new StringBuilder();
            var matches = MatchesFromText(inputText, @"<a([^\>]*)>");

            foreach (var match in matches)
            {
                sb.AppendLine(match.ToString());
            }

            return sb.ToString();
        }

        private string GetHrefAsText(string inputText) 
        {
            StringBuilder sb = new StringBuilder();
            var matches = MatchesFromText(inputText, @"href=""\S*""");

            foreach (var match in matches)
            {
                string textBetweenColums = match.ToString().Substring(6);

                sb.AppendLine(textBetweenColums.Substring(0, textBetweenColums.Length - 1));
            }

            return sb.ToString();
        }

        private MatchCollection MatchesFromText(string input, string regexExpresion)
        {
                var rgx = new Regex(regexExpresion, RegexOptions.IgnoreCase);
                var matches = rgx.Matches(input);
                return matches;
        }
    }
}