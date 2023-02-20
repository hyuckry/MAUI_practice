using System.Xml;
using System.ServiceModel.Syndication;
using System.Text.Json;

namespace NewsAppMaui.Services
{
    public class RssService: IRssService
    {
        HttpClient _client; 
        IHttpsClientHandlerService _httpsClientHandlerService;

        public RssService(IHttpsClientHandlerService service) 
        {
#if DEBUG
            _httpsClientHandlerService = service;
            HttpMessageHandler handler = _httpsClientHandlerService.GetPlatformMessageHandler();
            if (handler != null)
                _client = new HttpClient(handler);
            else
                _client = new HttpClient();
#else
            _client = new HttpClient();
#endif
        }

        public async Task<IEnumerable<SyndicationItem>> GetRssFeedItemsAsync(Uri uri)
        {
            var rssFeed = await _client.GetStringAsync(uri);
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
