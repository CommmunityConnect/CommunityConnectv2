using CommunityConnect.ViewModel;
using Microsoft.Maui.Controls;

namespace CommunityConnect.Pages
{
    public partial class signup : ContentPage
    {
        public signup()
        {
            InitializeComponent();
            BindingContext = new SignupViewModel();
        }

        private void OnTappedNavigateToLogin(object sender, EventArgs e)
        {
            // Navigate to login page
            Shell.Current.GoToAsync("signin");
        }

        private void OnShowPasswordCheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            passwordEntry.IsPassword = !e.Value;
        }

        private async void OnSignUpClicked(object sender, EventArgs e)
        {
            // Validate user type selection
            if (userTypePicker.SelectedItem == null)
            {
                await DisplayAlert("Error", "Please select a user type.", "OK");
                return;
            }
            var userType = userTypePicker.SelectedItem as string;
            var username = nameEntry.Text;
            var email = emailEntry.Text;
            var password = passwordEntry.Text;

            // Perform sign-up logic here
            // Perform validation for sign-up
            if (string.IsNullOrWhiteSpace(username) || username.Length > 13 || !IsLettersOnly(username))
            {
                await DisplayAlert("Error", "Username must be less than 13 characters long.", "OK");
                return;
            }
            if (username.Length > 13)
            {
                await DisplayAlert("Error", "Username must not exceed 13 characters.", "OK");
                return;
            }

            if (!IsValidPassword(password))
            {
                await DisplayAlert("Error", "Password must be 8-12 digits long and contain only numbers.", "OK");
                return;
            }
            if (!IsValidEmail(email))
            {
                await DisplayAlert("Error", "Email must be in a valid format and contain '@'.", "OK");
                return;
            }
            await DisplayAlert("Success", $"Signed up as {userType}", "OK");
            await Shell.Current.GoToAsync("signin");
        }
        // Check if username contains only letters
        private bool IsLettersOnly(string input)
        {
            return input.All(char.IsLetter);
        }
        // Email validation
        private bool IsValidEmail(string email)
        {
            return !string.IsNullOrWhiteSpace(email) && email.Contains("@");
        }
        // Password validation
        private bool IsValidPassword(string password)
        {
            return password.Length >= 8 && password.Length < 13 && password.All(char.IsDigit);
        }
    }
}


