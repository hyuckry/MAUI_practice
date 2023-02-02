namespace PassXYZ.Vault2.Views;

public partial class LocalizationPage : ContentPage
{
	public LocalizationPage(LocalizationViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;
	}

}
