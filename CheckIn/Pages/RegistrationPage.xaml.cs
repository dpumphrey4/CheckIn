using CheckIn.ViewModel;
#if WINDOWS
using Microsoft.UI.Xaml;
#endif

namespace CheckIn.Pages;

public partial class RegistrationPage : ContentPage
{
	public RegistrationPage(RegistrationViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
        var timer = Microsoft.Maui.Controls.Application.Current.Dispatcher.CreateTimer();
        timer.Interval = TimeSpan.FromSeconds(1);
        timer.Tick += (s, e) => UpdateTime();
        timer.Start();
    }

    protected void UpdateTime()
    {
        ((RegistrationViewModel)BindingContext).UpdateTimeCommand.Execute(null);
    }

    protected override void OnSizeAllocated(double width, double height)
    {
        base.OnSizeAllocated(width, height);
        if (width >= 1024)
        {
            entries.MaximumWidthRequest = width * 0.5;
            entries.MinimumWidthRequest = width * 0.5;
        }
        else if (width < 450)
        {
            entries.MaximumWidthRequest = width;
            entries.MinimumWidthRequest = width;
        }
        else
        {
            entries.MaximumWidthRequest = width * 0.8;
            entries.MinimumWidthRequest = width * 0.8;

        }
    }

}