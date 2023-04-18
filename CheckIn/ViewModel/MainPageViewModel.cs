using CheckIn.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CheckIn.ViewModel;

public partial class MainPageViewModel : ObservableObject
{
    [RelayCommand]
    async Task Register()
    {
        await Shell.Current.GoToAsync($"{nameof(RegistrationPage)}");
    }

    [RelayCommand]
    async Task PreviousVisitors()
    {
        await Shell.Current.GoToAsync($"{nameof(PreviousVisitorsPage)}");
    }

}

