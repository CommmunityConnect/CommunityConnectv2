using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;
using CommunityConnect.model;

namespace CommunityConnect.Services
{
    public static class IncidentReportService
    {
        private static readonly string filePath = Path.Combine(FileSystem.AppDataDirectory, "incident_reports.json");

        public static async Task<List<IncidentReport>> LoadReportsAsync()
        {
            try
            {
                var json = await File.ReadAllTextAsync(filePath);
                var reports = JsonSerializer.Deserialize<List<IncidentReport>>(json);
                return reports;
            }
            catch (Exception ex)
            {
                // Log or handle the exception as needed
                Debug.WriteLine($"Error loading reports from JSON: {ex.Message}");
                return new List<IncidentReport>(); // Return an empty list in case of an error
            }
        }


        public static async Task SaveReportsAsync(List<IncidentReport> reports)
        {
            string json = JsonSerializer.Serialize(reports);
            await File.WriteAllTextAsync(filePath, json);
        }

        public static async Task SubmitReportAsync(IncidentReport report)
        {
            var reports = await LoadReportsAsync();
            reports.Add(report);
            await SaveReportsAsync(reports);
        }

        public static async Task ApproveReportAsync(string reportId)
        {
            var reports = await LoadReportsAsync();
            var report = reports.FirstOrDefault(r => r.Id == reportId);
            if (report != null)
            {
                report.IsApproved = true;
                await SaveReportsAsync(reports);
            }
        }

        public static async Task DeclineReportAsync(string reportId)
        {
            var reports = await LoadReportsAsync();
            reports.RemoveAll(r => r.Id == reportId);
            await SaveReportsAsync(reports);
        }

        public static async Task<List<IncidentReport>> GetApprovedReportsAsync()
        {
            var reports = await LoadReportsAsync();
            return reports.Where(r => r.IsApproved).ToList();
        }

        internal static async Task SaveReportAsync(IncidentReport incident)
        {
            throw new NotImplementedException();
        }
    }


}