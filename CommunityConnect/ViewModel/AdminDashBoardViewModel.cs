using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityConnect.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CommunityConnect.ViewModel
{
    public partial class AdminDashBoardViewModel : ObservableObject
    {
        public AdminDashBoardViewModel()
        {
             
        }

        [RelayCommand]
        private async Task NavigateToValidationRequests()
        {
            var alertsViewModel = new AlertsViewModel(); // Create an instance of AlertsViewModel
            var adminApprovalPage = new AdminApprovalPage(alertsViewModel); // Pass it to AdminApprovalPage
            
            // Absolute navigation route to Admin Approval Page
            await Shell.Current.GoToAsync(nameof(AdminApprovalPage));
        }



        [RelayCommand]
        private async Task NavigateToManageUsers()
        {
            // Navigation logic for Manage Users
            await Shell.Current.GoToAsync(nameof(ManageUsersPage));
        }
    }
}
