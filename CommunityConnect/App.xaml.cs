using CommunityConnect.ViewModel;

namespace CommunityConnect
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            // Register ViewModel
            Resources.Add("ValidationRequestsViewModel", new ValidationRequestsViewModel());

            MainPage = new AppShell();

        }
    }
}
