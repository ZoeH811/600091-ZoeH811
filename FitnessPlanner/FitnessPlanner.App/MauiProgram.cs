using Microsoft.Extensions.Logging;
using FitnessPlanner.App.ViewModels;
using FitnessPlanner.App.Views;
using FitnessPlanner.App.Services;
using FitnessPlanner.App.Services.Interfaces;
using FitnessPlanner.App.Data;
using FitnessPlanner.App.Data.Interfaces;
using FitnessPlanner.App.Data.Repositories;

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

            builder.Services.AddSingleton<IActivityService, ActivityService>(); //Temporary in-memory activity data

            builder.Services.AddTransient<DiaryViewModel>();
            builder.Services.AddTransient<DiaryPage>();

            builder.Services.AddSingleton<AppDatabase>();
            builder.Services.AddSingleton<IUserProfileRepository, SQLiteUserProfileRepository>();

            return builder.Build();
        }
    }
}
