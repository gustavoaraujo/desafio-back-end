using BackEndInfoglobo.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BackEndInfoglobo.Controller
{
    public class Crawler
    {
        private Parser parser;

        public string Crawl()
        {
            var url = "http://revistaautoesporte.globo.com/rss/ultimas/feed.xml";
            var response = Request(url);

            if (!response.Contains("Response Error: "))
            {
                parser = new Parser(response);

                Feed feed = new Feed
                {
                    items = parser.ParseItems()
                };

                return feed.ToString();
            }

            return response;
        }

        public string Request(string url)
        {
            try
            {
                WebRequest request = WebRequest.Create(url);
                WebResponse response = request.GetResponse();
                StreamReader responseStream = new StreamReader(response.GetResponseStream());
                string responseText = responseStream.ReadToEnd();
                response.Close();

                return responseText;
            }
            catch(Exception ex)
            {
                return string.Format("Response Error: {0}", ex.Message);
            }
        }
    }
}
