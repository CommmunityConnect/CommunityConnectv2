using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityConnect.model;

namespace CommunityConnect.ViewModel
{
    public partial class ValidationRequestsViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public ObservableCollection<ValidationRequest> Requests { get; set; }

        public ValidationRequestsViewModel()
        {
            // Sample data
            Requests = new ObservableCollection<ValidationRequest>
            {
                new ValidationRequest { IncidentType = "Theft", Location = "Mentz", ReporterEmail = "Reg@gmail.com", ImageUrl = "placeholder_image.png" },
                new ValidationRequest { IncidentType = "Theft", Location = "Mentz", ReporterEmail = "Reg@gmail.com", ImageUrl = "placeholder_image.png" },
                new ValidationRequest { IncidentType = "Theft", Location = "Mentz", ReporterEmail = "Reg@gmail.com", ImageUrl = "placeholder_image.png" }
            };
        }
        [RelayCommand]
        private void ApproveRequest(ValidationRequest request)
        {
            // Logic to handle approval
            Requests.Remove(request);
        }

        [RelayCommand]
        private void RejectRequest(ValidationRequest request)
        {
            // Logic to handle rejection
            Requests.Remove(request);
        }
    }
}
