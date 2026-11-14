using Microsoft.Extensions.Logging;
using FitnessPlanner.App.ViewModels;
using FitnessPlanner.App.Views;

namespace FitnessPlanner.App
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

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<DashboardViewModel>();
            builder.Services.AddTransient<DashboardPage>();

            return builder.Build();
        }
    }
}
