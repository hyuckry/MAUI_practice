using NewsAppMaui.Views;

namespace NewsAppMaui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
        Routing.RegisterRoute("article", typeof(ArticlePage));

		this.HomeTab.Icon = ImageSource.FromResource("NewsAppMaui.Resources.Images.home.png", this.GetType().Assembly);
        this.SectionsTab.Icon = ImageSource.FromResource("NewsAppMaui.Resources.Images.categories.png", this.GetType().Assembly);
        this.BookmarksTab.Icon = ImageSource.FromResource("NewsAppMaui.Resources.Images.bookmarks.png", this.GetType().Assembly);
        this.ProfileTab.Icon = ImageSource.FromResource("NewsAppMaui.Resources.Images.profile.png", this.GetType().Assembly);
    }
}
