using NewsAppMaui.Models;
using NewsAppMaui.Services;

namespace NewsAppMaui.ViewModels
{
    public class SectionsViewModel
    {
        public SectionsViewModel(INewsService news)
        {
            this.Sections = news.GetCategories();
        }

        public ICollection<Category> Sections { get; set; }
    }
}
