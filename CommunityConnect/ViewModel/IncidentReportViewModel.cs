using System.Collections.ObjectModel;
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
            IncidentReports = new ObservableCollection<IncidentReport>();

            // Load reports asynchronously
            LoadReports();

            SubmitReportCommand = new Command(async () => await OnSubmitReport());
            UploadPhotoCommand = new Command(async () => await OnUploadPhoto());
        }

        private async void LoadReports()
        {
            var reports = await IncidentReportService.LoadReportsAsync();
            foreach (var report in reports)
            {
                IncidentReports.Add(report);
            }
        }

        private async Task OnSubmitReport()
        {
            if (string.IsNullOrWhiteSpace(Description) ||
                string.IsNullOrWhiteSpace(IncidentType) ||
                string.IsNullOrWhiteSpace(Location) ||
                Photo == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill all fields before submitting.", "OK");
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

            await IncidentReportService.SubmitReportAsync(incident);

            await Application.Current.MainPage.DisplayAlert("Success", "Report submitted successfully!", "OK");

            await Shell.Current.GoToAsync("MainPage");
        }

        private async Task OnUploadPhoto()
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
