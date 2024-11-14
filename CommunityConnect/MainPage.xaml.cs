using System.Collections.ObjectModel;
using CommunityConnect.model;

namespace CommunityConnect
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<CommunityConnect.model.MenuItem> MenuItems { get; set; }


        public MainPage()
        {
            InitializeComponent();

            MenuItems = new ObservableCollection<CommunityConnect.model.MenuItem>
{
    new CommunityConnect.model.MenuItem { Name = "Real-Time Incident Reporting", Icon = "incident_report_icon.png" },
    new CommunityConnect.model.MenuItem { Name = "Real-Time Alerts (Sebatakgomo)", Icon = "alerts_icon.png" },
    new CommunityConnect.model.MenuItem { Name = "Incident Feed/Map View", Icon = "map_view_icon.png" },
    new CommunityConnect.model.MenuItem { Name = "Community Collaboration", Icon = "collaboration_icon.png" },
    new CommunityConnect.model.MenuItem { Name = "People of Interest", Icon = "missing_people_icon.png" },
    new CommunityConnect.model.MenuItem { Name = "User Profile and Contributions", Icon = "user_profile_icon.png" }
};


            BindingContext = this;
        }
    }
}