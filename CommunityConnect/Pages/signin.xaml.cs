using CommunityConnect.ViewModel;
using Microsoft.Maui.Controls;

namespace CommunityConnect.Pages;

public partial class signin : ContentPage
{
    private bool _isPasswordVisible = false;

    public signin()
    {
        InitializeComponent();
        BindingContext = new SigninViewModel(); // Bind ViewModel to XAML
    }

    // Button Sign In Clicked
    private async void BtnSignInClicked(object sender, EventArgs e)
    {
        // Validate input fields
        if (string.IsNullOrWhiteSpace(UsernameEntry.Text))
        {
            await DisplayAlert("Error", "Please enter your username.", "OK");
            return;
        }
        if (string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            await DisplayAlert("Error", "Please enter your password.", "OK");
            return;
        }
        // Get the selected user type from the Picker
        string selectedUserType = userTypePicker.SelectedItem?.ToString();
        // Navigate to MainPage
        // Navigate based on user type
        if (selectedUserType == "Admin")
        {
            await Navigation.PushAsync(new AdminDashBoardPage());
        }
        else
        {
            await Navigation.PushAsync(new MainPage());
        }
    }

    // Label Clicked to Navigate to Sign Up
    private async void OnLabelClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new signup());
    }

    // Toggle Password Visibility
    private void OnPasswordVisibilityTapped(object sender, TappedEventArgs e)
    {
        _isPasswordVisible = !_isPasswordVisible;
        PasswordEntry.IsPassword = !_isPasswordVisible;
    }
}