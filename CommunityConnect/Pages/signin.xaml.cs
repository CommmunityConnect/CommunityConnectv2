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
        // Validate user type selection
        if (userTypePicker.SelectedItem == null)
        {
            await DisplayAlert("Error", "Please select a user type.", "OK");
            return;
        }
        // Validate input fields
        if (string.IsNullOrWhiteSpace(UsernameEntry.Text) )
        {
            await DisplayAlert("Error", "Please enter your username.", "OK");
            return;
        }
        if (string.IsNullOrWhiteSpace(PasswordEntry.Text))
        {
            await DisplayAlert("Error", "Please enter your password.", "OK");
            return;
        }
        // Validate username length
        if (UsernameEntry.Text.Length > 13 || !IsLettersOnly(UsernameEntry.Text))
        {
            await DisplayAlert("Error", "Username must be less 13 characters long.", "OK");
            return;
        }
        // Validate password
        if (!IsValidPassword(PasswordEntry.Text))
        {
            await DisplayAlert("Error", "Password must be 8-12 digits long and contain only numbers.", "OK");
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
    // Check if username contains only letters
    private bool IsLettersOnly(string input)
    {
        return input.All(char.IsLetter);
    }
    // Password validation
    private bool IsValidPassword(string password)
    {
        return password.Length >= 8 && password.Length < 13 && password.All(char.IsDigit);
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