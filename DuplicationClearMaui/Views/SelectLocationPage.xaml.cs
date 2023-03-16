using DuplicationClearMaui.ViewModels;

namespace DuplicationClearMaui.Views;

public partial class SelectLocationPage : ContentPage
{
	public SelectLocationPage(SelectLocationVM vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}