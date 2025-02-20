using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using CommunityConnect.Data;
using CommunityConnect.Pages;
using CommunityConnect.model;
using CommunityConnect.Services;
using CommunityToolkit.Mvvm.Input;

namespace CommunityConnect.ViewModel
{
    public partial class AlertsViewModel : ObservableObject
    {
        private readonly IncidentReportService _incidentReportService;
        private readonly AppDatabase _database;

        public ObservableCollection<Alert> Alerts { get; set; } = new();

        public ObservableCollection<IncidentReport> ApprovedIncidents { get; set; } = new();
        public IRelayCommand LoadAlertsCommand { get; }

        public AlertsViewModel(AppDatabase database, IncidentReportService incidentReportService)
        {
            _database = database;
            _incidentReportService = incidentReportService;
            LoadAlertsCommand = new RelayCommand(async () => await LoadAlertsAsync());
        }
        private async Task LoadAlertsAsync()
        {
            var alerts = await _database.GetAlertsAsync();
            Alerts.Clear();
            foreach (var alert in alerts)
                Alerts.Add(alert);
        }


        private async void LoadApprovedIncidents()
        {
            var incidents = await _incidentReportService.GetApprovedReports();
            ApprovedIncidents.Clear();
            foreach (var incident in incidents)
            {
                ApprovedIncidents.Add(incident);
            }
        }
    }

}

