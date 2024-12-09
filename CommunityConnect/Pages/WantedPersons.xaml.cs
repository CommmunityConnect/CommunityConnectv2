using CommunityConnect.ViewModel;

namespace CommunityConnect.Pages;

public partial class WantedPersons : ContentPage
{
	public WantedPersons()
	{
		InitializeComponent();
		BindingContext = new WantedPersonsViewModel();
	}
}