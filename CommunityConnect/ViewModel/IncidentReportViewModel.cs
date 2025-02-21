using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using CommunityConnect.model;
using CommunityConnect.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Maui.Controls;

namespace CommunityConnect.ViewModel
{
    public partial class IncidentReportViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public ObservableCollection<IncidentReport> IncidentReports { get; }

        private string description;
        private string incidentType;
        private string location;
        private ImageSource photo;

        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }

        public string IncidentType
        {
            get => incidentType;
            set => SetProperty(ref incidentType, value);
        }

        public string Location
        {
            get => location;
            set => SetProperty(ref location, value);
        }

        public ImageSource Photo
        {
            get => photo;
            set => SetProperty(ref photo, value);
        }

        public List<string> IncidentTypes { get; } = new()
        {
            "Assault", "Accident", "Robbery", "Pothole", "Water Crisis", "Fire", "Other"
        };

        public ICommand SubmitReportCommand { get; }
        public ICommand UploadPhotoCommand { get; }

        public IncidentReportViewModel()
        {
            // Access IncidentReports directly from the static service
            IncidentReports = IncidentReportService.IncidentReports;

            SubmitReportCommand = new Command(OnSubmitReport);
            UploadPhotoCommand = new Command(OnUploadPhoto);
        }

        private void OnSubmitReport()
        {
            if (string.IsNullOrWhiteSpace(Description) ||
                string.IsNullOrWhiteSpace(IncidentType) ||
                string.IsNullOrWhiteSpace(Location) ||
                Photo == null)
            {
                Application.Current.MainPage.DisplayAlert("Error", "Please fill all fields before submitting.", "OK");
                return;
            }

            var incident = new IncidentReport
            {
                Description = Description,
                IncidentType = IncidentType,
                Location = Location,
                ImagePath = Photo?.ToString(),
                IsApproved = false
            };

            // Use IncidentReportService directly (since it's static)
            IncidentReportService.SubmitIncident(incident);

            Application.Current.MainPage.DisplayAlert("Success", "Report submitted successfully!", "OK");

            Shell.Current.GoToAsync("MainPage");
        }

        private async void OnUploadPhoto()
        {
            var result = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = FilePickerFileType.Images,
                PickerTitle = "Select a photo"
            });

            if (result != null)
            {
                Photo = ImageSource.FromFile(result.FullPath);
            }
        }
    }
}
