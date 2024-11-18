using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CommunityConnect.ViewModel
{
    public class LandingPageViewModel
    {
        public ICommand NavigateToIncidentCommand { get; }

        public LandingPageViewModel()
        {
            NavigateToIncidentCommand = new Command(async () =>
            {
                // Navigate to IncidentReportPage
                await Shell.Current.GoToAsync(nameof(Pages.IncidentReportPage));
            });
        }
    }
}
