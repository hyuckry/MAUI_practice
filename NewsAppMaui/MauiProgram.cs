using Microsoft.Extensions.Logging;
using Microsoft.Maui.Hosting;
using NewsAppMaui.Services;
using NewsAppMaui.ViewModels;
using NewsAppMaui.Views;

namespace NewsAppMaui;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.RegisterViewModels()
            .RegisterAppServices()
            .ConfigureFonts(fonts =>
			{
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("NotoSerif-Bold.ttf", "NotoSerifBold");
                fonts.AddFont("Poppins-Bold.ttf", "PoppinsBold");
                fonts.AddFont("Poppins-SemiBold.ttf", "PoppinsSemibold");
                fonts.AddFont("Poppins-Regular.ttf", "Poppins");
                fonts.AddFont("MaterialIconsOutlined-Regular.otf", "Material");
            });

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}

    public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder mauiAppBuilder)
    {
        mauiAppBuilder.Services.AddSingleton<INewsService, MockNewsService>();

        return mauiAppBuilder;
    }

    public static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
	{
        mauiAppBuilder.Services.AddTransient<HomeViewModel>();
        mauiAppBuilder.Services.AddTransient<SectionsViewModel>();
        mauiAppBuilder.Services.AddTransient<ArticleViewModel>();
        mauiAppBuilder.Services.AddTransient<BookmarksViewModel>();

        mauiAppBuilder.Services.AddTransient<HomePage>();
        mauiAppBuilder.Services.AddTransient<SectionPage>();
        mauiAppBuilder.Services.AddTransient<ArticlePage>();
        mauiAppBuilder.Services.AddTransient<BookmarkPage>();

        return mauiAppBuilder;
    }



}
