using System.Net;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;

namespace NewsApiTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            string query = "경제"; // 검색할 문자열
            string url = "https://openapi.naver.com/v1/search/news.json?query=" + query; // JSON 결과
            // string url = "https://openapi.naver.com/v1/search/blog.xml?query=" + query;  // XML 결과
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Headers.Add("X-Naver-Client-Id", "th9HE15pX9wwEfg0wVLq"); // 클라이언트 아이디
            request.Headers.Add("X-Naver-Client-Secret", "Y52e_EJeJn");       // 클라이언트 시크릿
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string status = response.StatusCode.ToString();
            if (status == "OK")
            {
                Stream stream = response.GetResponseStream();
                StreamReader reader = new StreamReader(stream, Encoding.UTF8);
                string text = reader.ReadToEnd();
                Console.WriteLine(text);
            }
            else
            {
                Console.WriteLine("Error 발생=" + status);
            }
        }

        [Test]
        public void RssTest()
        {
            SyndicationFeed feed = null;

            try
            {
                //https://visualstudiomagazine.com/rss-feeds/news.aspx
                string rssUrl = "https://news.sbs.co.kr/news/SectionRssFeed.do?sectionId=01&plink=RSSREADER";
                using (var reader = XmlReader.Create(rssUrl))
                {
                    feed = SyndicationFeed.Load(reader);
                }
            }
            catch { } // TODO: Deal with unavailable resource.

            if (feed != null)
            {
                foreach (var element in feed.Items)
                {
                    Console.WriteLine($"Title: {element.Title.Text}");
                    Console.WriteLine($"Summary: {element.Summary.Text}");
                }
            }
        }
    }
}