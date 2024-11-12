namespace CommunityConnect.Pages;

public partial class LandingPage : ContentPage
{
    private readonly List<string> _texts = new()
        {
            "Neighborhood Watch in your Pocket",
            "Stay Informed, Stay Safe.",
            "Keep Your Surroundings in Check. ",
            "Knowing What’s Happening, and Where.",
            "Work Together for a Safer Environment."

        };

    // method for the button getStarted navigation 
    private async void OnGetStartedButtonClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new signin()); 
    }
    public LandingPage()
	{
		InitializeComponent();

        // Handle the CurrentItemChanged event
        slideshow.CurrentItemChanged += (s, e) =>
        {
            int index = slideshow.Position;
            textLabel.Text = _texts[index];
        };

        // Set initial text
        textLabel.Text = _texts[0];
    }
}