using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

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
            SubmitReportCommand = new Command(SubmitReport);
            UploadPhotoCommand = new Command(UploadPhoto);
        }

        private async void SubmitReport()
        {
            // Placeholder logic for submitting the report
            await Application.Current.MainPage.DisplayAlert("Success", "Report submitted successfully!", "OK");
        }

        private async void UploadPhoto()
        {
            // Placeholder logic for uploading a photo
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
