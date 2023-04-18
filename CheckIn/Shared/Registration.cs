
using System.Text.Json.Serialization;

namespace CheckIn.Shared
{
    public class Registration
    {
        public Registration(string firstname, string lastname, string middlename, string date) 
        {
            _firstname = firstname;
            _middlename = middlename;
            _lastname = lastname;
            _date = date;
        }

        // This is just to get deserialization to work
        [JsonConstructor]
        public Registration() { }

        public string _firstname { get; set; }
        public string _middlename { get; set; }
        public string _lastname { get; set; }
        public string _date { get; set; }
    }
}
