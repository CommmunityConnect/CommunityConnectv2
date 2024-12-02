using Microsoft.Maui.Controls;

namespace CommunityConnect.Pages;

public partial class signin : ContentPage
{
    private bool _isPasswordVisible = false;

    public signin()
    {
        InitializeComponent();
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
        // Navigate to MainPage
        await Navigation.PushAsync(new MainPage());
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