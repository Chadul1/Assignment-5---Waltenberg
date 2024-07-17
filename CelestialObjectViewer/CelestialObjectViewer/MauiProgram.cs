using CelestialObjectViewer.Models;
using CelestialObjectViewer.Services;
using CelestialObjectViewer.ViewModels;
using CelestialObjectViewer.Views;
using Microsoft.Extensions.Logging;

namespace CelestialObjectViewer
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            // Register services
            builder.Services.AddSingleton<IPlanetService, PlanetService>();
            builder.Services.AddSingleton<IStarService, StarService>();
            builder.Services.AddTransient<MainPageViewModel>();
            builder.Services.AddTransient<CelestialObjectPage>();


            builder.Services.AddSingleton<SessionInfo>();
            /*
             * Dependency Injection (DI): In MauiProgram.cs, the SessionInfo class is registered as a 
             * singleton using the AddSingleton method. This ensures that there is only one instance of 
             * SessionInfo throughout the application's lifecycle.
                Thread-Safe Singleton: The Lazy<T> type ensures that the SessionInfo instance is created
                in a thread-safe manner.
             */



#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
