using Microsoft.Maui.Controls;

namespace CommunityConnect.Pages
{
    public partial class signup : ContentPage
    {
        public signup()
        {
            InitializeComponent();
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            // Validate fields
            if (string.IsNullOrWhiteSpace(nameEntry.Text) ||
                string.IsNullOrWhiteSpace(emailEntry.Text) ||
                string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                await DisplayAlert("Error", "Please fill in all fields before signing up.", "OK");
                return;
            }

            // Simulate successful account creation
            await DisplayAlert("Success", "Account created successfully!", "OK");

            // Redirect to the login page
            await Shell.Current.GoToAsync("signin");
        }

        // Event handler for when the "Show Password" checkbox is checked/unchecked
        private void OnShowPasswordCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            // Toggle the IsPassword property of the passwordEntry
            passwordEntry.IsPassword = !e.Value;
        }
        private async void OnTappedNavigateToLogin(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new signin());
        }
    }
}