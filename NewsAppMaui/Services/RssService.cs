using System.Xml;
using System.ServiceModel.Syndication;

namespace NewsAppMaui.Services
{
    public class RssService: IRssService
    {
        public RssService() { }

        public async Task<IEnumerable<SyndicationItem>> GetRssFeedItemsAsync(Uri uri)
        {
            using (var client = new HttpClient())
            {
                var rssFeed = await client.GetStringAsync(uri);
                var stream = new StringReader(rssFeed);                  

                SyndicationFeed feed = null;
                try
                {
                    using (var reader = XmlReader.Create(stream))
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


                return feed.Items;
            }
        }
    }
}
