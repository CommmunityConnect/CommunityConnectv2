using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityConnect.ViewModel;
using CommunityConnect.ViewModels;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace CommunityConnect.Pages;

public partial class AdminApprovalPage : ContentPage
{
    public AdminApprovalPage()
    {
        InitializeComponent();
        BindingContext = new AdminApprovalViewModel(new AlertsViewModel()); // Set the view model
    }
    // Constructor with AlertsViewModel parameter
    public AdminApprovalPage(AlertsViewModel alertsViewModel)
    {
        InitializeComponent();
        BindingContext = new AdminApprovalViewModel(alertsViewModel); // Set the provided view model
    }
}
   


