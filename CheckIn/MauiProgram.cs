using CheckIn.Pages;
using CheckIn.ViewModel;
using Microsoft.Extensions.Logging;
namespace CheckIn;

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

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainPageViewModel>();

		builder.Services.AddSingleton<ConfirmationPage>();

		builder.Services.AddTransient<RegistrationPage>();
		builder.Services.AddTransient<RegistrationViewModel>();

		builder.Services.AddTransient<PreviousVisitorsPage>();
		builder.Services.AddTransient<PreviousVisitorsViewModel>();

		return builder.Build();
	}
}
