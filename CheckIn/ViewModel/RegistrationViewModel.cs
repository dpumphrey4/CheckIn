using CheckIn.Pages;
using CheckIn.Shared;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Threading.Tasks;

namespace CheckIn.ViewModel
{
    public partial class RegistrationViewModel : ObservableValidator
    {
        [Required(ErrorMessage = "First name is required.")]
        [ObservableProperty]
        public required string _firstName;

        [ObservableProperty]
        public string _middleName;

        [Required(ErrorMessage = "Last name is required.")]
        [ObservableProperty]
        public required string _lastName;

        [ObservableProperty]
        public DateTime currentDate = DateTime.Now;


        [RelayCommand]
        void UpdateTime()
        {
            CurrentDate = DateTime.Now;
        }

        [RelayCommand]
        public async void TakePhoto()
        {
            // THIS DOES NOT WORK ON WINDOWS RIGHT NOW IN MAUI, MIGHT WORK IN WINUI 3
            // IT ALSO DOES NOT WORK ON ANDROID 33
            if (MediaPicker.Default.IsCaptureSupported)
            {
                //FileResult photo = await MediaPicker.Default.CapturePhotoAsync();
                FileResult photo = await MediaPicker.CapturePhotoAsync();

                if (photo != null)
                {
                    // save the file into local storage
                    string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                    using Stream sourceStream = await photo.OpenReadAsync();
                    using FileStream localFileStream = File.OpenWrite(localFilePath);

                    await sourceStream.CopyToAsync(localFileStream);
                }
            }
        }

        [RelayCommand]
        public async void Submit()
        {
            if(String.IsNullOrEmpty(FirstName) || String.IsNullOrWhiteSpace(FirstName) 
                || String.IsNullOrEmpty(LastName) || String.IsNullOrWhiteSpace(LastName)
                || !LastName.All(Char.IsLetter) || !FirstName.All(Char.IsLetter))
            {
                return;
            }

            await CreateFile();
            await Shell.Current.GoToAsync($"{nameof(ConfirmationPage)}");
        }

        private async Task CreateFile()
        {
            DateTime temp = DateTime.Now;

            string time = temp.ToString();

            Registration registration = new Registration(FirstName, LastName, MiddleName, time);

            string path = FileSystem.Current.AppDataDirectory;
            string fileName = temp.ToString("yyyyMMdd HH_mm_ss") + "_" + registration._firstname + "_" + registration._lastname;
            string fullPath = Path.Combine(path, fileName);

            string thingy = JsonSerializer.Serialize(registration);

            await File.WriteAllTextAsync(fullPath, JsonSerializer.Serialize(registration));

            Registration registration1 = JsonSerializer.Deserialize<Registration>(thingy);

        }
    }
}
