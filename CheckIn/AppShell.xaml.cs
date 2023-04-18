using CheckIn.Pages;

namespace CheckIn;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();
		Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
		Routing.RegisterRoute(nameof(PreviousVisitorsPage), typeof(PreviousVisitorsPage));
		Routing.RegisterRoute(nameof(ConfirmationPage), typeof(ConfirmationPage));
	}
}
