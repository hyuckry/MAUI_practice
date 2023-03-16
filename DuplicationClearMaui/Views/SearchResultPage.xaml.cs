using DuplicationClearMaui.ViewModels;

namespace DuplicationClearMaui.Views;

public partial class SearchResultPage : ContentPage
{
	public SearchResultPage(SearchResultVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}