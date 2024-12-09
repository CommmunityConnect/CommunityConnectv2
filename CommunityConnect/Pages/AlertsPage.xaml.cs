using CommunityConnect.ViewModel;

namespace CommunityConnect.Pages;

public partial class AlertsPage : ContentPage
{
	public AlertsPage()
	{
		InitializeComponent();
		BindingContext = new AlertsViewModel();
	}
}