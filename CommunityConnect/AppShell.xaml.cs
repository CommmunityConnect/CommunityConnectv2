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
            typeof(signin),
            typeof(signup)
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