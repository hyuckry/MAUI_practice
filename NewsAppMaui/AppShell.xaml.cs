namespace NewsAppMaui;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

		this.HomeTab.Icon = ImageSource.FromResource("NewsAppMaui.Resources.Images.home.png", this.GetType().Assembly);
	}
}
