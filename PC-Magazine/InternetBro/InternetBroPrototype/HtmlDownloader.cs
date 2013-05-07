namespace Crawler
{
    using System;
    using System.Net;

    /// <summary>
    /// Automatically uncompress GZiped response
    /// http://stackoverflow.com/questions/2973208/automatically-decompress-gzip-response-via-webclient-downloaddata
    /// </summary>

    class MyWebClient : WebClient
    {
        protected override WebRequest GetWebRequest(Uri address)
        {
            HttpWebRequest request = base.GetWebRequest(address) as HttpWebRequest;
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;
            return request;
        }
    }

    /// <summary>
    /// Downloads the html strings from a url and returns it via the TextResult property
    /// </summary>
    public class HtmlDownloader
    {
        private static MyWebClient webClient;
        public string UrlAdress {get; private set;}
        public string HtmlText { get; private set; }

        static HtmlDownloader()
        {
            webClient = new MyWebClient();
        }

        public HtmlDownloader(string urlAdress)
        {
            this.UrlAdress = urlAdress;
            this.HtmlText = GetStringFromURL(this.UrlAdress);
        }

        private string GetStringFromURL(string urlAdress)
        {
            try
            {
                using (webClient)
                {
                    webClient.Headers.Add("Accept-Encoding", "");
                    return webClient.DownloadString(urlAdress);
                }
            }
            catch (WebException we)
            {
                throw new WebException("Something went wrong!", we);
            }
        }
    }

 
}