using CommunityConnect.ViewModel;

namespace CommunityConnect.Pages;

public partial class AdminDashBoardPage : ContentPage
{
	public AdminDashBoardPage()
	{
		InitializeComponent();
        BindingContext = new AdminDashBoardViewModel();
    }
     
}