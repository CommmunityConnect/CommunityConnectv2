using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityConnect.model;
using CommunityConnect.Services;
using CommunityConnect.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
 

namespace CommunityConnect.ViewModels
{
    public class AdminApprovalViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
    {
        public ObservableCollection<IncidentReport> PendingReports { get; set; } = new();
        private AlertsViewModel _alertsViewModel;

        public ICommand ApproveCommand => new Command<IncidentReport>(async (report) => 
        {
            Debug.WriteLine("Approve command executed");
            await ApproveReportAsync(report);
        });
    
        public ICommand DeclineCommand => new Command<IncidentReport>(async (report) => 
        {
    Debug.WriteLine("Decline command executed");
        await DeclineReportAsync(report);
      });
        public AdminApprovalViewModel(AlertsViewModel alertsViewModel)
        {
            _alertsViewModel = alertsViewModel;
            LoadPendingReportsAsync();
        }

        public async Task LoadPendingReportsAsync()
        {
            try
            {
                var reports = await IncidentReportService.LoadReportsAsync();
                if (reports != null)
                {
                    PendingReports.Clear();
                    foreach (var report in reports.Where(r => !r.IsApproved))
                    {
                        PendingReports.Add(report);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error loading reports: {ex.Message}");
            }
        }

        public async Task ApproveReportAsync(IncidentReport report)
        {
            if (report == null) return;

            try
            {
                await IncidentReportService.ApproveReportAsync(report.Id);
                Device.BeginInvokeOnMainThread(() =>
                {
                    _alertsViewModel.ApprovedReports.Add(report);
                    PendingReports.Remove(report);
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error approving report: {ex.Message}");
            }
        }

        public async Task DeclineReportAsync(IncidentReport report)
        {
            if (report == null) return;

            try
            {
                await IncidentReportService.DeclineReportAsync(report.Id);
                Device.BeginInvokeOnMainThread(() =>
                {
                    PendingReports.Remove(report);
                });
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Error declining report: {ex.Message}");
            }
        }
    }
}
