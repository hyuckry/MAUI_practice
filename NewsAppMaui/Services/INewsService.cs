using NewsAppMaui.Models;
using NewsAppMaui.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Syndication;
using System.Text;
using System.Threading.Tasks; 

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

        Task<IEnumerable<Article>> INewsService.GetBookmarkedArticles()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Category>> INewsService.GetCategories()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Article>> INewsService.GetLatestArticles()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Article>> INewsService.GetPopularArticles()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Article>> INewsService.GetRecommendedArticles()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<string>> INewsService.GetTags()
        {
            throw new NotImplementedException();
        }
    }
}
