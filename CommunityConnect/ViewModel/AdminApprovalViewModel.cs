using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityConnect.model;
using CommunityConnect.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Windows.Input;
using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CommunityConnect.ViewModel
{
    public class AdminApprovalViewModel : BindableObject
    {
        private readonly IncidentReportService _incidentReportService;

        public ObservableCollection<IncidentReport> PendingReports { get; set; } = new();

        public RelayCommand<int> ApproveCommand { get; }
        public RelayCommand<int> DeclineCommand { get; }

        public AdminApprovalViewModel()
        {
            _incidentReportService = new IncidentReportService();
            System.Diagnostics.Debug.WriteLine("AdminApprovalViewModel Initialized");

            ApproveCommand = new RelayCommand<int>(async (id) => await ApproveReport(id));
            DeclineCommand = new RelayCommand<int>(async (id) => await DeclineReport(id));

            PendingReports = new ObservableCollection<IncidentReport>();
            LoadPendingReports();
        }

        /// <summary>
        /// Loads all pending incident reports for admin review.
        /// </summary>
        public async void LoadPendingReports()
        {
            var reports = await _incidentReportService.GetPendingReports();
            PendingReports.Clear();
            foreach (var report in reports)
            {
                PendingReports.Add(report);
            }
            Console.WriteLine($"AdminApprovalPage Loaded {PendingReports.Count} reports.");
        }

        /// <summary>
        /// Refreshes the pending reports list.
        /// </summary>
        public async Task RefreshReports()
        {
            var reports = await _incidentReportService.GetPendingReports();
            PendingReports.Clear();
            foreach (var report in reports)
            {
                PendingReports.Add(report);
            }
            Console.WriteLine($"Admin page refreshed: {PendingReports.Count} reports.");
        }

        /// <summary>
        /// Approves a report and updates the list.
        /// </summary>
        public async Task ApproveReport(int reportId)
        {
            await _incidentReportService.UpdateReportStatus(reportId, true);
            await Application.Current.MainPage.DisplayAlert("Success", "Incident approved.", "OK");
            LoadPendingReports(); // Refresh the list
        }

        /// <summary>
        /// Declines a report and updates the list.
        /// </summary>
        public async Task DeclineReport(int reportId)
        {
            await _incidentReportService.UpdateReportStatus(reportId, false);
            await Application.Current.MainPage.DisplayAlert("Notice", "Incident declined.", "OK");
            LoadPendingReports(); // Refresh the list
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}