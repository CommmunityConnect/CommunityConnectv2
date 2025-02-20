using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityConnect.ViewModel;

namespace CommunityConnect.Pages
{
    public partial class IncidentReportPage : ContentPage
    {
        public IncidentReportPage()
        {
            InitializeComponent();
            BindingContext = new IncidentReportViewModel();
        }
    }
}
