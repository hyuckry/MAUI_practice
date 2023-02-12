namespace PassXYZ.Vault2.Views;

public partial class SamplePage : ContentPage
{
	public SamplePage(SampleViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}
}
