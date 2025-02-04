using CommunityConnect.ViewModel;

namespace CommunityConnect
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();

        }

        public App(ValidationRequestsViewModel validationRequestsViewModel) : this()
        {
            BindingContext = validationRequestsViewModel;
        }
    }
}
