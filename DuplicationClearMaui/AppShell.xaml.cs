using DuplicationClearMaui.Views;

namespace DuplicationClearMaui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute(nameof(SearchResultPage), typeof(SearchResultPage));
    }
}
