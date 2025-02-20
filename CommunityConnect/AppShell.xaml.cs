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
            typeof(AlertsPage),
            typeof(WantedPersons),
            typeof(MissingPersons),
            typeof(Announcements),
            typeof(GeneralDiscussions),
            typeof(signin),
            typeof(signup),
            typeof(MainPage),
            typeof(AdminApprovalPage),
            typeof(ManageUsersPage)
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