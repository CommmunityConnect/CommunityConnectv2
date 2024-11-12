namespace CommunityConnect.Pages;
using SkiaSharp.Views.Maui.Controls.Hosting;

public partial class signin : ContentPage
{
	//btn sign in when clicked
	private async void BtnSignInClicked(object sender, EventArgs e)
	{
        await Navigation.PushAsync(new MainPage());
    }

    //this code is for the label making the label a clickable object 
    private async void OnLabelClicked(object sender, EventArgs e)
    {
        // Navigate to the SignUpPage
        await Navigation.PushAsync(new signup());
    }
    public signin()
	{
		InitializeComponent();
	}
}