using System.Collections.ObjectModel;
using System.Windows.Input;
using CommunityConnect.model;
 
using Microsoft.Maui.Controls;

namespace CommunityConnect.ViewModels
{
    public class AdminApprovalViewModel : BindableObject
    {
        public ObservableCollection<Report> PendingReports { get; set; }
        public ICommand ApproveReportCommand { get; }
        public ICommand DeclineReportCommand { get; }

        public AdminApprovalViewModel()
        {
            PendingReports = new ObservableCollection<Report>
            {
                
                new Report { IncidentType = "Accident", Description = "Car accident at intersection.", Location = "5th Avenue", ImageUrl = "accidentimage.png" }
            };

            ApproveReportCommand = new Command<Report>(ApproveReport);
            DeclineReportCommand = new Command<Report>(DeclineReport);
        }

        private async void ApproveReport(Report report)
        {
            if (report == null) return;

            bool confirm = await App.Current.MainPage.DisplayAlert("Confirm", "Are you sure you want to approve this report?", "Yes", "No");
            if (confirm)
            {
                PendingReports.Remove(report);
                await App.Current.MainPage.DisplayAlert("Success", "Report has been successfully approved.", "OK");
                await Shell.Current.GoToAsync("..");
            }
        }

        private async void DeclineReport(Report report)
        {
            if (report == null) return;

            bool confirm = await App.Current.MainPage.DisplayAlert("Confirm", "Are you sure you want to decline this report?", "Yes", "No");
            if (confirm)
            {
                PendingReports.Remove(report);
                await App.Current.MainPage.DisplayAlert("Declined", "Report has been declined.", "OK");
                await Shell.Current.GoToAsync("..");
            }
        }
    }
}
