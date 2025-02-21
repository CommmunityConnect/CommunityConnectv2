using System;
using Microsoft.Maui.Controls;

namespace CommunityConnect.Pages
{
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void LoadUserData()
        {
            // Simulated user data, replace with actual user service call
            FullNameLabel.Text = "Mabore";
            EmailLabel.Text ="mabore@gmail.com";
            ProfileImage.Source = "profilepic.png";
        }

        private async void OnChangePasswordTapped(object sender, EventArgs e)
        {
            await DisplayAlert("Change Password", "Do you want to change your password.", "OK");
            await Navigation.PushAsync(new ChangePasswordPage());
        }



        private async void OnDeleteAccountTapped(object sender, EventArgs e)
        {
            bool confirm = await DisplayAlert("Delete Account", "Are you sure you want to delete your account?", "Yes", "No");
            if (confirm)
            {
                // TODO: Add actual account deletion logic here (e.g., call an API to remove user data)

                // Show a message
                await DisplayAlert("Account Deleted", "Your account has been successfully deleted.", "OK");

                // Navigate to the login page (assuming LoginPage.xaml exists)
                Application.Current.MainPage = new NavigationPage(new signin());
            }
        }


        private async void OnLogoutTapped(object sender, EventArgs e)
        {
            await DisplayAlert("Logout", "You have been logged out.", "OK");
            // Navigate to login page if needed
        }

        private async void OnHelpTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new HelpPage());
        }

        private async void OnRateAppTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RateAppPage());
        }

        private async void OnAboutAppTapped(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutAppPage());
        }
    }
}
