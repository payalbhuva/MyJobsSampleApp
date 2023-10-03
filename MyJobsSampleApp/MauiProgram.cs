using Microsoft.Extensions.Logging;
using MyJobsSampleApp.Data;
using MyJobsSampleApp.View;
using MyJobsSampleApp.ViewModel;
using CommunityToolkit.Maui;

namespace MyJobsSampleApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("Free-Solid-900.otf", "FreeSolid");
            });

        builder.Services.AddSingleton<DatabaseContext>();

        builder.Services.AddSingleton<Login>();
        builder.Services.AddSingleton<LoginViewModel>();

        builder.Services.AddTransient<JobsPage>();
		builder.Services.AddTransient<JobsPageViewModel>();
        builder.Services.AddTransient<JobsDetail>();
        builder.Services.AddTransient<JobsDetailViewModel>();

        builder.Services.AddTransient<ImagePopup>();
        builder.Services.AddTransient<ImagePopupViewModel>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

