using System.Collections.ObjectModel;
using CommunityConnect.model;

namespace CommunityConnect.Services
{
    public static class IncidentReportService
    {
        private static int nextId = 1; // Initialize a counter for IDs

        public static ObservableCollection<IncidentReport> IncidentReports { get; set; } = new();

        public static void SeedTestData()
        {
            if (IncidentReports.Count == 0)
            {
                IncidentReports.Add(new IncidentReport
                {
                    Id = nextId++, // Incrementing ID for test data
                    Title = "Test Report",
                    Description = "This is a test incident report.",
                    Location = "Test Location",
                    IsApproved = false
                });
            }
        }

        public static bool SubmitIncident(IncidentReport report)
        {
            report.Id = nextId++; // Assign a unique ID
            report.IsApproved = false;
            IncidentReports.Add(report);
            return true;
        }

        public static ObservableCollection<IncidentReport> GetPendingReports()
        {
            return new ObservableCollection<IncidentReport>(IncidentReports.Where(r => !r.IsApproved));
        }

        public static ObservableCollection<IncidentReport> GetApprovedReports()
        {
            return new ObservableCollection<IncidentReport>(IncidentReports.Where(r => r.IsApproved));
        }

        public static void UpdateReportStatus(int id, bool isApproved)
        {
            var report = IncidentReports.FirstOrDefault(r => r.Id == id);
            if (report != null)
            {
                report.IsApproved = isApproved;
            }
        }
    }

}