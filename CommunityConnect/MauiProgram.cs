using CommunityConnect.Services; // to be able to use skia sharp animations 
using CommunityConnect.ViewModel;
using Microsoft.Extensions.Logging;
using SkiaSharp.Views.Maui.Controls.Hosting;

 
using CommunityConnect.ViewModel;
 
using CommunityConnect.Data;
using CommunityConnect.Services;
using CommunityConnect.ViewModels;

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
            builder.Services.AddSingleton<ILocationService, LocationService>();

#if DEBUG
            builder.Logging.AddDebug();
#endif
            // ✅ Register SQLite Database
        string dbPath = Path.Combine(FileSystem.AppDataDirectory, "CommunityConnect.db");
        builder.Services.AddSingleton<AppDatabase>();
            
            builder.Services.AddSingleton<IncidentReportViewModel>();
            builder.Services.AddSingleton<AdminApprovalViewModel>();
            builder.Services.AddSingleton<AlertsViewModel>();






            return builder.Build();
        }
    }
}