using System;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;

namespace CommunityConnect.Pages
{
    public partial class EmergencyContactPage : ContentPage
    {
        public EmergencyContactPage()
        {
            InitializeComponent();
        }

        private async void OnPoliceEmergencyTapped(object sender, EventArgs e)
        {
            await DialNumber("10111");
        }

        private async void OnAmbulanceEmergencyTapped(object sender, EventArgs e)
        {
            await DialNumber("10177");
        }

        private async void OnChildlineTapped(object sender, EventArgs e)
        {
            await DialNumber("0800055555");
        }

        private async Task DialNumber(string number)
        {
            try
            {
                var phoneNumber = $"tel:{number}";
                await Launcher.OpenAsync(phoneNumber);
            }
            catch (Exception ex)
            {
                // Handle any exceptions that might occur
                await DisplayAlert("Error", "Unable to make the call: " + ex.Message, "OK");
            }
        }
    }
}
