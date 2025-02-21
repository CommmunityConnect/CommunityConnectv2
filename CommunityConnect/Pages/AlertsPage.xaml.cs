using System.Collections.ObjectModel;

namespace CommunityConnect.Pages
{
    public partial class AlertsPage : ContentPage
    {
        public ObservableCollection<Alert> Alerts { get; set; }

        public AlertsPage()
        {
            InitializeComponent();
            Alerts = new ObservableCollection<Alert>
            {
                new Alert { Title = "🚗 Accident Alert!", Location = "Main Street & 5th Avenue", TimeReported = "Reported 5 min ago" },
                new Alert { Title = "🔥 Fire Alert!", Location = "Downtown Mall, Entrance 3", TimeReported = "Reported 10 min ago" },
                new Alert { Title = "💧 Water Leak!", Location = "Pinewood Estate, Block B", TimeReported = "Reported 20 min ago" }
            };

            BindingContext = this;
        }
    }

    public class Alert
    {
        public string Title { get; set; }
        public string Location { get; set; }
        public string TimeReported { get; set; }
    }
}
