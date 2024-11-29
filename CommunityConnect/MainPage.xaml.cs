using CommunityConnect.Pages;
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
    new CommunityConnect.model.MenuItem { Name = "Real-Time Incident Reporting", Icon = "complaint.png" },
    new CommunityConnect.model.MenuItem { Name = "Real-Time Alerts (Sebatakgomo)", Icon = "alert.png" },
    new CommunityConnect.model.MenuItem { Name = "Incident Feed/Map View", Icon = "satelliteview.png" },
    new CommunityConnect.model.MenuItem { Name = "Community Collaboration", Icon = "chat.png" },
    new CommunityConnect.model.MenuItem { Name = "People of Interest", Icon = "question.png" },
    new CommunityConnect.model.MenuItem { Name = "User Profile and Contributions", Icon = "user.png" },
     new CommunityConnect.model.MenuItem { Name = "Emergency Contact", Icon = "emergencycall.png" }
};


            BindingContext = this;
        }


        private async void OnTappedIncidentReport(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new IncidentReportPage());
        }

        private async void OnTappedAlerts(object sender, TappedEventArgs e)
        {
            await Navigation.PushAsync(new AlertsPage());
        }
    }
}