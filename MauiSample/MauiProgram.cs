using MauiSample.Services;
using MauiSample.ViewModels;
using Microsoft.Extensions.Logging;

namespace MauiSample
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            MauiAppBuilder builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            builder.Services.AddSingleton<ITaskService, FakeTaskService>();
            builder.Services.AddSingleton<HomeViewModel>();
            builder.Services.AddSingleton<NewTaskViewModel>();
            builder.Services.AddSingleton<TaskDetailsViewModel>();
            builder.Services.AddSingleton<TasksViewModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}
