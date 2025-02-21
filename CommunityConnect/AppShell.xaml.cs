using CommunityConnect.Pages;

namespace CommunityConnect
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //calling Routes() class
            RegisterRoute();
        }
        private readonly static Type[] _types =
        [
            typeof(IncidentReportPage),
             
            typeof(WantedPersons),
            typeof(MissingPersons),
            typeof(AlertsPage),
            typeof(Announcements),
            typeof(GeneralDiscussions),
            typeof(signin),
            typeof(signup),
            typeof(MainPage),
            typeof(AdminApprovalPage),
            typeof(ManageUsersPage),
            typeof(ChangePasswordPage),
            typeof(AboutAppPage),
            typeof(HelpPage),
            typeof(RateAppPage)
        ];
        private static void RegisterRoute()
        {
            foreach (var type in _types)
            {
                //register routes
                Routing.RegisterRoute(type.Name, type);
            }
        }
    }
}