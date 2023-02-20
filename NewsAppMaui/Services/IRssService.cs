using NewsAppMaui.Models;
using System.Xml.Linq;
using System.Xml;
using System.ServiceModel.Syndication;

namespace NewsAppMaui.Services
{
    public interface IRssService
    {
        Task<IEnumerable<SyndicationItem>> GetRssFeedItemsAsync(Uri uri);
    }
}
