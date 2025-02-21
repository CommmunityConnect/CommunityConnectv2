using System;
using Microsoft.Maui.Controls;

namespace CommunityConnect.Pages
{
    public partial class ChangePasswordPage : ContentPage
    {
        public ChangePasswordPage()
        {
            InitializeComponent();
        }

        private async void OnChangePasswordClicked(object sender, EventArgs e)
        {
            string currentPassword = CurrentPasswordEntry.Text;
            string newPassword = NewPasswordEntry.Text;
            string confirmPassword = ConfirmPasswordEntry.Text;

            if (string.IsNullOrWhiteSpace(currentPassword) ||
                string.IsNullOrWhiteSpace(newPassword) ||
                string.IsNullOrWhiteSpace(confirmPassword))
            {
                await DisplayAlert("Error", "Please fill in all fields.", "OK");
                return;
            }

            if (newPassword != confirmPassword)
            {
                await DisplayAlert("Error", "New passwords do not match.", "OK");
                return;
            }

            // TODO: Implement actual password update logic (API call, database update, etc.)
            await DisplayAlert("Success", "Your password has been changed successfully!", "OK");

            // Navigate back to Profile page
            await Navigation.PopAsync();
        }
    }
}
