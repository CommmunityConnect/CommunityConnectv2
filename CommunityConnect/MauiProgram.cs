using Microsoft.Extensions.Logging;
using CommunityConnect.ViewModel;
using SkiaSharp.Views.Maui.Controls.Hosting; // to be able to use skia sharp animations 

namespace CommunityConnect
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseSkiaSharp()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });
            // Register ViewModels
            builder.Services.AddSingleton<ValidationRequestsViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
