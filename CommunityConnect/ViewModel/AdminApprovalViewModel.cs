using System.Collections.ObjectModel;
using System.ComponentModel;
using CommunityConnect.model;
using CommunityConnect.Model;
using CommunityConnect.Services;
using CommunityToolkit.Mvvm.ComponentModel;

namespace CommunityConnect.ViewModel
{
    public partial class AdminApprovalViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public ObservableCollection<IncidentReport> PendingReports { get; } = new();

        public AdminApprovalViewModel()
        {
            LoadPendingReports();
        }

        private void LoadPendingReports()
        {
            PendingReports.Clear();
            foreach (var report in IncidentReportService.GetPendingReports())
            {
                PendingReports.Add(report);
            }
        }

        public void ApproveReport(IncidentReport report)
        {
            if (report != null)
            {
                IncidentReportService.UpdateReportStatus(report.Id, true);
                LoadPendingReports(); // Refresh list after approving
                                      // Notify AlertsViewModel to refresh approved reports
                AlertsViewModel.Instance.LoadApprovedReports();
            }
        }

        public void DeclineReport(IncidentReport report)
        {
            if (report != null)
            {
                IncidentReportService.UpdateReportStatus(report.Id, false);
                LoadPendingReports(); // Refresh list after declining
            }
        }
    }

}
