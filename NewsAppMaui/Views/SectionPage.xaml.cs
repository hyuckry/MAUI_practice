using NewsAppMaui.Services;
using NewsAppMaui.ViewModels;

namespace NewsAppMaui.Views;

public partial class SectionPage : ContentPage
{
    public SectionPage(INewsService news)
    {
        InitializeComponent();
        this.BindingContext = new SectionsViewModel(news);
    }
}