using Microsoft.Extensions.Logging; 

namespace PassXYZ.Vault;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    //➊ In each platform, the entry point is in platform-specific code. The entry point calls the CreateMauiApp function,
	//which is a method of the MauiProgram static class.
    {
        var builder = MauiApp.CreateBuilder();
		//➋ Inside CreateMauiApp, it calls the CreateBuilder function, which is a method of the MauiApp static class,
		//and returns a MauiAppBuilder instance, which provides a.NET Generic Host interface.
		builder
			.UseMauiApp<App>()
            //❹ The App class referenced in the UseMauiApp method is the root object of our application.
			//Let’s review the definition of the App class in App.xaml.cs:            
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
        //➌ The return value of CreateMauiApp is a MauiApp instance, which is the entry point of your app.
    }
}
