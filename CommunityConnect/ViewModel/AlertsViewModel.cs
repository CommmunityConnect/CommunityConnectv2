using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityConnect.model;
using CommunityConnect.Services;

namespace CommunityConnect.ViewModel
{
    public class AlertsViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public ObservableCollection<IncidentReport> ApprovedReports { get; set; } = new();
        public AlertsViewModel()
        {
            LoadApprovedReportsAsync();
        }

        public async Task LoadApprovedReportsAsync()
        {
            var reports = await IncidentReportService.GetApprovedReportsAsync();
            ApprovedReports.Clear();
            foreach (var report in reports)
            {
                ApprovedReports.Add(report);
            }
        }
    }


}