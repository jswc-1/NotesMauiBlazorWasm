using Microsoft.Extensions.Logging;
using NotesMauiBlazorWasm.Common.Interfaces;
using NotesMauiBlazorWasm.Common.Services;
using NotesMauiBlazorWasm.Data;
using NotesMauiBlazorWasm.Services;

namespace NotesMauiBlazorWasm
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

            builder.Services.AddTransient<AuthServices>();
            builder.Services.AddSingleton<IAlertService, AlertService>();
            builder.Services.AddSingleton<IStorageService, StorageService>();
#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
    }
}