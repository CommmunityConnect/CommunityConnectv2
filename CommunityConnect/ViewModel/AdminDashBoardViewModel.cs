using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CommunityConnect.Pages;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace CommunityConnect.ViewModel
{
    public partial class AdminDashBoardViewModel : ObservableObject
    {
        public AdminDashBoardViewModel()
        {
            // Initialize commands or other logic
        }

        [RelayCommand]
        private async Task NavigateToValidationRequests()
        {
            // Navigation logic for Validation Requests
            await Shell.Current.GoToAsync(nameof(ValidationRequestsPage));
        }

        [RelayCommand]
        private async Task NavigateToManageUsers()
        {
            // Navigation logic for Manage Users
            await Shell.Current.GoToAsync(nameof(ManageUsersPage));
        }
    }
}
