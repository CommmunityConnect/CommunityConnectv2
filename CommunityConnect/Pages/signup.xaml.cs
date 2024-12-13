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
            var userType = userTypePicker.SelectedItem as string;
            var username = nameEntry.Text;
            var email = emailEntry.Text;
            var password = passwordEntry.Text;

            // Perform sign-up logic here

            await DisplayAlert("Success", $"Signed up as {userType}", "OK");
            await Shell.Current.GoToAsync("signin");
        }
    }
}


