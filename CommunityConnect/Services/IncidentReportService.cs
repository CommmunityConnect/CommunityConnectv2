using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace CommunityConnect.Services
{
    public class IncidentReportService
    {
        private readonly SQLiteAsyncConnection _database;

        public IncidentReportService()
        {
            _database = DatabaseHelper.GetDatabaseConnection();
        }
        public async Task SeedTestData()
        {
            var existingReports = await _database.Table<IncidentReport>().ToListAsync();
            if (existingReports.Count == 0)
            {
                await _database.InsertAsync(new IncidentReport
                {
                    Title = "Test Report",
                    Description = "This is a test incident report.",
                    Location = "Test Location",
                    IsApproved = false
                });
            }
        }
        public async Task<bool> UpdateIncident(IncidentReport incident)
        {
            int result = await _database.UpdateAsync(incident);
            return result > 0;
        }

        public async Task<bool> SubmitIncident(IncidentReport report)
        {
            report.IsApproved = false;  // Mark as pending by default
            report.IsDeclined = false;

            int result = await _database.InsertAsync(report);
            return result > 0;
        }
        public async Task<List<IncidentReport>> GetAllReports()
        {
            var reports = await _database.Table<IncidentReport>().ToListAsync();
            Console.WriteLine($"Total reports: {reports.Count}"); // Debugging
            return reports;
            //return await _database.Table<IncidentReport>().ToListAsync();
        }
        public   async Task<List<IncidentReport>> GetPendingReports()
        {
            var reports = await _database.Table<IncidentReport>().Where(r => r.IsApproved == false).ToListAsync();
            Console.WriteLine($"Fetched {reports.Count} pending reports");
            return reports;
        }
        public async Task<List<IncidentReport>> GetApprovedReports()
        {
            return await _database.Table<IncidentReport>().Where(i => i.IsApproved).ToListAsync();
        }

        public async Task UpdateReportStatus(int id, bool isApproved)
        {
            var report = await _database.Table<IncidentReport>().Where(r => r.Id == id).FirstOrDefaultAsync();
            if (report != null)
            {
                report.IsApproved = isApproved;
                await _database.UpdateAsync(report);
            }
        }
    }
}
