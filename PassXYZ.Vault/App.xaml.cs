using Android.OS.Storage;

namespace PassXYZ.Vault;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		//MainPage = new AppShell();
        //AppShell is an instance of Shell, and it defines the UI of the initial page of the app.
		//Application creates an instance of the Window class within which the application will run and views will be displayed.
		//In the App class, we can overwrite the CreateWindow method to manage the lifecycle, which we will see soon.
    }

    protected override Window CreateWindow(IActivationState activationState)
    {
        //return base.CreateWindow(activationState);
        return new PxWindow(new MainPage());
    }
}
