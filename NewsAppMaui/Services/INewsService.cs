using NewsAppMaui.Models;
using NewsAppMaui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks;
using ThreadNetwork;

namespace NewsAppMaui.Services
{
    public interface INewsService
    {
        Task<IEnumerable<string>> GetTags();
        Task<IEnumerable<Category>> GetCategories();
        Task<IEnumerable<Article>> GetLatestArticles();
        Task<IEnumerable<Article>> GetRecommendedArticles();
        Task<IEnumerable<Article>> GetPopularArticles();
        Task<IEnumerable<Article>> GetBookmarkedArticles();
        Task<string> GetArticleBody(string articleId);
    }

    public class NewsService : INewsService
    {
        HttpClient _client;
        IHttpsClientHandlerService _httpsClientHandlerService;

        public NewsService(IHttpsClientHandlerService service)
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

        public Task<string> GetArticleBody(string articleId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SyndicationItem>> GetBookmarkedArticles()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Category>> GetCategories()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Article>> GetLatestArticles()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Article>> GetPopularArticles()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<Article>> GetRecommendedArticles()
        {
            throw new NotImplementedException();
        }

        public Task<ICollection<string>> GetTags()
        {
            throw new NotImplementedException();
        }
    }
}
