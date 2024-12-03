namespace CommunityConnect.Pages
{
    public partial class Profile : ContentPage
    {
        public Profile()
        {
            InitializeComponent();
        }

        // This method should not be inside the constructor and should be defined outside
        private async void OnLogoutTapped(object sender, EventArgs e)
        {
            // Navigate to the sign-in page
            await Navigation.PushAsync(new signin());
        }
    }
}
