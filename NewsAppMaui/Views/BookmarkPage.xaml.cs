using NewsAppMaui.Services;
using NewsAppMaui.ViewModels;

namespace NewsAppMaui.Views;

public partial class BookmarkPage : ContentPage
{
    public BookmarkPage(INewsService news)
    {
        InitializeComponent();
        this.BindingContext = new BookmarksViewModel(news);
    }
}