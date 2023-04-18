using CheckIn.ViewModel;

namespace CheckIn.Pages;

public partial class PreviousVisitorsPage : ContentPage
{
	public PreviousVisitorsPage(PreviousVisitorsViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}