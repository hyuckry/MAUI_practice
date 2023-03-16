using DuplicationClearMaui.ViewModels;
using DuplicationClearMaui.Views;
using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;

namespace DuplicationClearMaui;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureSyncfusionCore()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });
        builder.Services.AddSingleton<SearchResultVM>();
        builder.Services.AddSingleton<SelectLocationVM>();

#if DEBUG
        builder.Logging.AddDebug();
#endif


        return builder.Build();
    }
}
