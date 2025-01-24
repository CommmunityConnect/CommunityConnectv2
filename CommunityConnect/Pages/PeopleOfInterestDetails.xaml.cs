using CommunityConnect.ViewModel;
using System.Windows.Input;
using CommunityConnect.Model;
using CommunityToolkit.Mvvm.Input;

namespace CommunityConnect.Pages
{
    public partial class PeopleOfInterestDetails : ContentPage
    {
        public PeopleOfInterestDetails()
        {
            InitializeComponent();
            BindingContext = new PeopleOfInterestDetailsViewModel();
        }
    }

    public class PeopleOfInterestDetailsViewModel : BindableObject
    {
        // Properties for binding
        public string CurrentPhoto { get; set; }
        public Person SelectedPerson { get; set; }

        // Commands for binding
        public ICommand PreviousPhotoCommand { get; }
        public ICommand NextPhotoCommand { get; }
        public ICommand ReportSightingCommand { get; }
        public ICommand ContactAuthoritiesCommand { get; }

        // Constructor
        public PeopleOfInterestDetailsViewModel()
        {
            // Initialize data
            SelectedPerson = new Person
            {
                Name = "John Doe",
                Status = "Missing",
                Description = "Last seen wearing a red jacket.",
                LastLocation = "Main Street, City Center",
                CaseDetails = "Case ID: 12345. Open for public assistance."
            };

            // Initialize commands
            ReportSightingCommand = new Command(OnReportSighting);
            ContactAuthoritiesCommand = new Command(OnContactAuthorities);
        }

        private void OnReportSighting()
        {
            // Logic to handle reporting a sighting
            App.Current.MainPage.DisplayAlert("Report Sighting", "Thank you for reporting the sighting. Authorities will review your input.", "OK");
        }

        private void OnContactAuthorities()
        {
            // Logic to contact authorities
            App.Current.MainPage.DisplayAlert("Contact Authorities", "Dialing the authorities' contact number...", "OK");
        }
    }

    // The Person class
    public class Person
    {
        public string Name { get; set; }
        public string Status { get; set; }
        public string Description { get; set; }
        public string LastLocation { get; set; }
        public string CaseDetails { get; set; }
    }
}
