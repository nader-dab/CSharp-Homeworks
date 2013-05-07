namespace Crawler
{
    using System;
    using System.Diagnostics;
    using System.Text;
    using System.Collections.Generic;
    /// <summary>
    /// The purpose of this class is to get all children website links from a starting parrent website according to the rules of
    /// the InternetBro task. It gets only links children of the current parrent link. 
    /// </summary>
    public class InternetBroFilter
    {
        /// <summary>
        /// http://konkurs.pcmagbg.net/                 Works
        /// http://www.youtube.com/watch?v=1kZQiLMZV1s  Works
        /// http://telerikacademy.com/                  Works
        /// </summary>

        public List<UrlLink> Children { get; private set; }

        public InternetBroFilter(string startingUrlAddress)
        {
            this.Children = GetChildren(startingUrlAddress);
        }

        private List<UrlLink> GetChildren(string startingUrlAddress)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            var html = new HtmlDownloader(startingUrlAddress).HtmlText;
            //WriteToFile.WriteTextToFile(html, "BeforeMod.txt");

            // Restrictions for the Pcmag website -> CANNOT use links that are in elements with id beggining with comment-
            if (startingUrlAddress.Contains("konkurs.pcmagbg.net"))
            {
                html = RemoveTags(html, "id=\"comment-");
                html = RemoveTags(html, "id=\"recentcomments");
            }

            // Restrictions for TelerikAcademy website -> CANNOT use links that are in elements with attribute:   
            // id="fb0021a1c"
            // id="RecentVideoHeader"
            // id="ForumPostsHeader"
            // id="BlogPostsHeader"
            // id="IndexCalendarHeader"
            if (startingUrlAddress.Contains("telerikacademy.com"))
            {
                html = RemoveTags(html, "id=\"f202640e64");
                html = RemoveTags(html, "id=\"RecentVideos");
                html = RemoveTags(html, "id=\"LatestForumPosts");
                html = RemoveTags(html, "id=\"BlogPosts");
                html = RemoveTags(html, "id=\"Calendar");
            }

            // Restrictions for youtube website -> can ONLY use links that are in elements with attribute:
            // id="eow-description"
            // class="primary-pane"
            if (startingUrlAddress.Contains("youtube.com"))
            {
                html = RetriveTags(html, "eow-description", "primary-pane");
            }

            //WriteToFile.WriteTextToFile(html, "AfterMod.txt");

            // Extract the anchor tags from text
            var tags = new LinkFilter(html).AnchorTags;
            //WriteToFile.WriteTextToFile(tags, "tags.txt");

            // Extract the href links from the anchor tags
            var hrefs = new LinkFilter(tags).LinksFromHrefs;
            //WriteToFile.WriteTextToFile(hrefs, "hrefs.txt");

            // Links can be only from the following sites:
            // http://academy.telerik.com
            // http://telerikacademy.com
            // http://konkurs.pcmagbg.net
            // http://www.youtube.com/playlist?list=
            // http://www.youtube.com/watch?v=
            // If NO protocol or server is present in the link -> relative link
            // All relative links are equal to the current website plus relative link
            // Current site is always Correct!
            // The resulting links are the allowed children links of the initial url address 


            List<UrlLink> linksList = new List<UrlLink>();
            var links = hrefs.Split(new char[] { '\n' }, StringSplitOptions.RemoveEmptyEntries);

            for (int index = 0; index < links.Length; index++)
            {
                UrlLink validUrl;
                links[index] = links[index].Trim();
                links[index] = links[index].Trim('\r');
                if (!links[index].StartsWith("http"))
                {
                    if (startingUrlAddress[startingUrlAddress.Length - 1] == '/')
                    {
                        validUrl = new UrlLink(startingUrlAddress + links[index], links[index]);
                    }
                    else
	                {
                        validUrl = new UrlLink(startingUrlAddress + "/" + links[index], links[index]);
	                }

                    linksList.Add(validUrl);
                }
                else
                {
                    if (links[index].StartsWith("http://academy.telerik.com") ||
                        links[index].StartsWith("http://telerikacademy.com") ||
                        links[index].StartsWith("http://konkurs.pcmagbg.net") ||
                        links[index].StartsWith("http://www.youtube.com/playlist?list=") ||
                        links[index].StartsWith("http://www.youtube.com/watch?v=")
                        )
                    {
                        validUrl = new UrlLink(links[index], links[index]);
                        linksList.Add(validUrl);
                    }
                }
            }

            //StringBuilder sb = new StringBuilder();
            //foreach (var l in linksList)
            //{
            //    sb.AppendLine(l.ToString());
            //}
            //WriteToFile.WriteTextToFile(sb.ToString(), "links.txt");

            //Process.Start(Environment.CurrentDirectory + "\\" + "BeforeMod.txt");
            //Process.Start(Environment.CurrentDirectory + "\\" + "AfterMod.txt");
            //Process.Start(Environment.CurrentDirectory + "\\" + "tags.txt");
            //Process.Start(Environment.CurrentDirectory + "\\" + "hrefs.txt");
            //Process.Start(Environment.CurrentDirectory + "\\" + "links.txt");

            //stopwatch.Stop();
            ColorConsole.Write(string.Format("FINISHED with {0} in {1:0.00} seconds.\n", startingUrlAddress, stopwatch.Elapsed.TotalSeconds), ConsoleColor.Green);

            return linksList;
        }


        // Returns as a string only the tag elements that are given as params
        private string RetriveTags(string html, params string[] tags)
        {
            StringBuilder sb = new StringBuilder();
            for (int index = 0; index < tags.Length; index++)
            {
                var tag = new ElementFilter(html, tags[index]).ElementById;
                while (!String.IsNullOrEmpty(tag))
                {
                    sb.Append(tag);
                    html = html.Replace(tag, string.Empty);
                    tag = new ElementFilter(html, tag).ElementById;
                }
            }
            return sb.ToString();
        }

        // Returns as a string the initial html text without the tag elemenent
        private string RemoveTags(string html, string tag)
        {
            var restriction = new ElementFilter(html, tag).ElementById;

            while (!String.IsNullOrEmpty(restriction))
            {
                html = html.Replace(restriction, string.Empty);
                restriction = new ElementFilter(html, tag).ElementById;
            }

            return html;
        }
    }
}