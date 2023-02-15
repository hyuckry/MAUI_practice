using NewsAppMaui.Services;
using NewsAppMaui.ViewModels;

namespace NewsAppMaui.Views;

public partial class HomePage : ContentPage
{
	public HomePage(INewsService news)
	{
		InitializeComponent();
		this.BindingContext = new HomeViewModel(news);
	}
}