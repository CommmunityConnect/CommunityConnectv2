using System.Collections.ObjectModel;
using System.Threading.Tasks;
using CommunityConnect.ViewModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
namespace CommunityConnect.Pages;

public partial class AdminApprovalPage : ContentPage
{
    public AdminApprovalPage()
    {
        InitializeComponent();
        BindingContext = new AdminApprovalViewModel(); // Set the view model
    }
}

