using CommunityConnect.Pages;

namespace CommunityConnect
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

           
            Routing.RegisterRoute("Home", typeof(LandingPage));
            Routing.RegisterRoute("Settings", typeof(SettingsPage));
            Routing.RegisterRoute("Alerts", typeof(AlertsPage));
            Routing.RegisterRoute("Forum", typeof(ForumPage));
        }
    }
}
