using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace CommunityConnect.ViewModel
{
    public class IncidentReportViewModel : INotifyPropertyChanged
    {
        private string description;
        private string incidentType;
        private string location;
        private ImageSource photo;

        // Properties with INotifyPropertyChanged
        public string Description
        {
            get => description;
            set
            {
                if (description != value)
                {
                    description = value;
                    OnPropertyChanged();
                }
            }
        }

        public string IncidentType
        {
            get => incidentType;
            set
            {
                if (incidentType != value)
                {
                    incidentType = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Location
        {
            get => location;
            set
            {
                if (location != value)
                {
                    location = value;
                    OnPropertyChanged();
                }
            }
        }

        public ImageSource Photo
        {
            get => photo;
            set
            {
                if (photo != value)
                {
                    photo = value;
                    OnPropertyChanged();
                }
            }
        }

        // List of possible incident types
        public List<string> IncidentTypes { get; } = new List<string>
        {
            "Assault",
            "Accident",
            "Robbery",
            "Pothole",
            "Water Crisis",
            "Fire",
            "Other"
        };

        // Commands for submitting and uploading
        public ICommand SubmitReportCommand { get; }
        public ICommand UploadPhotoCommand { get; }

        public IncidentReportViewModel()
        {
            SubmitReportCommand = new Command(OnSubmitReport);
            UploadPhotoCommand = new Command(OnUploadPhoto);
        }

        private async void OnSubmitReport()
        {
            if (string.IsNullOrWhiteSpace(Description) ||
                string.IsNullOrWhiteSpace(IncidentType) ||
                string.IsNullOrWhiteSpace(Location) ||
                Photo == null)
            {
                await Application.Current.MainPage.DisplayAlert("Error", "Please fill all fields before submitting.", "OK");
                return;
            }

            // Logic to submit the report
            await Application.Current.MainPage.DisplayAlert("Success", "Report submitted successfully!", "OK");
            await Shell.Current.GoToAsync("MainPage");
            //await Shell.Current.GoToAsync($"//{nameof(MainPage)}");
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

        // INotifyPropertyChanged implementation
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}

