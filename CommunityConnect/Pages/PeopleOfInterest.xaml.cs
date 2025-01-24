namespace CommunityConnect.Pages;

public partial class PeopleOfInterest : ContentPage
{
	public PeopleOfInterest()
	{
		InitializeComponent();
        
        AddGestureRecognizers();

    }
    private void AddGestureRecognizers()
    {
         
    }


    private async void NavigateToPage(string route)
    {
        await Shell.Current.GoToAsync(route);
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        
    }
}
