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
        // Missing Persons
        MissingPersonsFrame.GestureRecognizers.Add(new TapGestureRecognizer
        {
            Command = new Command(() => NavigateToPage("MissingPersons"))
        });

        // Wanted Persons
        WantedPersonsFrame.GestureRecognizers.Add(new TapGestureRecognizer
        {
            Command = new Command(() => NavigateToPage("WantedPersons"))
        });
    }


    private async void NavigateToPage(string route)
    {
        await Shell.Current.GoToAsync(route);
    }
}
