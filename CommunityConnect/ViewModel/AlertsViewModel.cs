using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityConnect.model;
using CommunityConnect.Services;

namespace CommunityConnect.ViewModel
{
    public partial class AlertsViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public static AlertsViewModel Instance { get; } = new(); // Singleton instance for global access

        public ObservableCollection<IncidentReport> ApprovedReports { get; } = new();

        public AlertsViewModel()
        {
            LoadApprovedReports();
        }

        public void LoadApprovedReports()
        {
            ApprovedReports.Clear();
            foreach (var report in IncidentReportService.GetApprovedReports())
            {
                ApprovedReports.Add(report);
            }
        }
    }

}