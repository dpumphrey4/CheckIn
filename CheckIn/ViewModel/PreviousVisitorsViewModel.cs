using CheckIn.Shared;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Collections.ObjectModel;
using System.IO.Enumeration;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace CheckIn.ViewModel
{
    public partial class PreviousVisitorsViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<Registration> _visitors;

        public PreviousVisitorsViewModel() 
        {
            string path = FileSystem.Current.AppDataDirectory;

            // Grabs all files in the AppData Directory
            // Can add ordering later if I want
            var enumeration = new FileSystemEnumerable<string>(
                    directory: FileSystem.Current.AppDataDirectory, // search AppData directory
                    transform: (ref FileSystemEntry entry) => entry.ToFullPath(),
                    options: new EnumerationOptions()
                    {
                        RecurseSubdirectories = true
                    })
            {
                // The following predicate will be used to filter the file entries
                /*ShouldIncludePredicate = (ref FileSystemEntry entry) => !entry.IsDirectory && Path.GetExtension(entry.ToFullPath()) == ".json"*/
            };

            // Create the list of strings that represent files
            _visitors = new ObservableCollection<Registration>();

            // Iterate through the appdata directory and make the objects
            // consider putting this in a async method, cause this could take some time
            foreach (string filePath in enumeration)
            {
                string json = File.ReadAllText(filePath);
                Registration person = JsonSerializer.Deserialize<Registration>(json);
                _visitors.Add(person);
            }
        }
    }
}
