using CommunityConnect.ViewModel;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityConnect.model;

namespace CommunityConnect.Pages;

public partial class AlertsViewModel : CommunityToolkit.Mvvm.ComponentModel.ObservableObject
{
    public ObservableCollection<Alert> Alerts { get; } = new();
    public IRelayCommand LoadAlertsCommand { get; }

    public AlertsViewModel()
    {
        LoadAlertsCommand = new RelayCommand(async () => await LoadAlertsAsync());
    }

    private async Task LoadAlertsAsync()
    {
        await Task.Delay(100);
    }
}
