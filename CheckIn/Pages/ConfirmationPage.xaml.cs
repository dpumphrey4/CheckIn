namespace CheckIn.Pages;

public partial class ConfirmationPage : ContentPage
{
	public ConfirmationPage()
	{
		InitializeComponent();
	}

	protected async void GoBack(object sender, EventArgs e) 
	{
        await Shell.Current.GoToAsync($"../..");
    }

}